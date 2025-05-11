using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DownCare.Infrastructure.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChatService _chatService;
        public ChatHub(UserManager<AppUser> userManager, IChatService chatService, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _chatService = chatService;
            _unitOfWork = unitOfWork;
        }
        //public override async Task OnConnectedAsync()
        //{
        //    var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //}
        public async Task SendMessage (string recipientUserId, string content)
        {
            var SenderId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (SenderId == null)
            {
                throw new UnauthorizedAccessException("Sender is not authenticated.");
            }
            var chatRoom = await _chatService.GerOrCreateChatRoomAsync(SenderId, recipientUserId);
            var message = new Message
            {
                SenderId = SenderId,
                ChatRoomID = chatRoom.Id,
                Content = content,
                IsRead = false
            };
            await _unitOfWork.Messages.CreateAsync(message);
            await _unitOfWork.SaveAsync();
            var recipient = await _userManager.FindByIdAsync(recipientUserId);
            if (recipient != null && !string.IsNullOrEmpty(recipient.ConnectionID))
            {
                await Clients.Client(recipient.ConnectionID).SendAsync("ReceiveMessage", new
                {
                    SenderId = SenderId,
                    Content = content,
                    Timestamp = message.DateTime
                });
            }
            await Clients.Caller.SendAsync("MessageSent", new
            {
                RecipientId = recipientUserId,
                Content = content,
                Timestamp = message.DateTime
            });
        }
        public async Task JoinGroup()
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new HubException("You are Unauthorized, Send Authorization");
            bool alreadyExist = await _unitOfWork.UserChatRooms.AnyAsync(u => u.ChatRoomId == 1 && u.UserId == userId);
            if (!alreadyExist)
            {
                UserChatRoom UserChatRoom = new UserChatRoom
                {
                    ChatRoomId = 1,
                    UserId = userId
                };
                await _unitOfWork.UserChatRooms.CreateAsync(UserChatRoom);
                if (await _unitOfWork.SaveAsync() <= 0)
                {
                    throw new HubException("Failed to join the group chat");
                }
                string message = $"{userId} joined the GroupChat";
                await Clients.Group("MomsGroupChat").SendAsync("UserJoined", message);
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, "MomsGroupChat");
        }
        public async Task SendGroupMessage(string message)
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            await Clients.Group("MomsGroupChat").SendAsync("ReceiveGroupMessage", new
            {
                Message = message,
                DisplayTime = DateTime.UtcNow.ToString("MMM dd, yyyy 'at' hh:mm tt"),
                UserName = user.UserName,
                UserImage = string.IsNullOrEmpty(user.ImagePath) ? "" : user.ImagePath, 
            });

            var groupMessage = new Message
            {
                SenderId = userId,
                ChatRoomID = 1,
                Content = message,
                IsRead = false
            };
            await _unitOfWork.Messages.CreateAsync(groupMessage);
            await _unitOfWork.SaveAsync();
        }
        public async Task LeftGroup()
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new HubException("You are Unauthorized, Send Authorization");
            bool alreadyExist = await _unitOfWork.UserChatRooms.AnyAsync(u => u.ChatRoomId == 1 && u.UserId == userId);
            if (alreadyExist)
            {
                var userLeft = await _unitOfWork.UserChatRooms.FirstOrDefaultAsync(u => u.ChatRoomId == 1 && u.UserId == userId);
                await _unitOfWork.UserChatRooms.DeleteAsync(userLeft);
                await _unitOfWork.SaveAsync();
                string message = $"{userId} Left the GroupChat";
                await Clients.Group("MomsGroupChat").SendAsync("UserLeft", message);
            }
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "MomsGroupChat");
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "MomsGroupChat");
            await base.OnDisconnectedAsync(exception);
        }
    }
}