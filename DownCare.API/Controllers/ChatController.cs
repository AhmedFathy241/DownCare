using DownCare.Core.Entities;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChatController(IChatService chatService, IHttpContextAccessor httpContextAccessor)
        {
            _chatService = chatService;
            _httpContextAccessor = httpContextAccessor;
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
            return Ok(res.Message);
        }
        [HttpGet("GroupMembers")]
        public async Task<IActionResult> ReadGroupMembers()
        {
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var res = await _chatService.ReadGroupMembersAsync(baseURL);
            return Ok(res.Model);
        }
    }
}