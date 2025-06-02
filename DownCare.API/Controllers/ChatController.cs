using DownCare.Core.Entities;
using DownCare.Infrastructure.Hubs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(IChatService chatService, IHttpContextAccessor httpContextAccessor,
            IHubContext<ChatHub> hubContext)
        {
            _chatService = chatService;
            _httpContextAccessor = httpContextAccessor;
            _hubContext = hubContext;
        }
        [Authorize]
        [HttpGet("ChatRooms")]
        public async Task<IActionResult> ReadAllChatRooms()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var res = await _chatService.ReadAllChatRoomsAsync(userId, baseURL);
            return Ok(res.Model);
        }
        [HttpGet("Messages/{ChatRoomId}")]
        public async Task<IActionResult> ReadMessages([FromRoute] int ChatRoomId)
        {
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            return Ok(await _chatService.ReadMessagesAsync(ChatRoomId, baseURL));
        }
        [HttpDelete("Message/{MessageId}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int MessageId)
        {
            var res = await _chatService.DeleteMessageAsync(MessageId);
            if (!res.IsSuccess)
                return BadRequest(res.Message);
            await _hubContext.Clients.Group("MomsGroupChat").SendAsync("MessageDeleted", new
            {
                messageId = MessageId
            });
            return Ok(res.Message);
        }
        [HttpGet("GroupMembers")]
        public async Task<IActionResult> ReadGroupMembers()
        {
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var res = await _chatService.ReadGroupMembersAsync(baseURL);
            return Ok(res.Model);
        }
        [Authorize]
        [HttpGet("PrivateMessages/{recipientUserId}")]
        public async Task<IActionResult> ReadPrivateMessages([FromRoute] string recipientUserId)
        {
            var SenderId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var res = await _chatService.ReadPrivateMessagesAsync(recipientUserId, SenderId, baseURL);
            return Ok(res.Model);
        }

    }
}