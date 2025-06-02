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
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{userId}");
            await base.OnConnectedAsync();
        }
        public async Task SendMessage (string recipientUserId, string messageContent)
        {
            var SenderId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Sender = await _userManager.FindByIdAsync(SenderId);
            var chatRoom = await _chatService.GerOrCreateChatRoomAsync(SenderId, recipientUserId);

            var privateMessage = new Message
            {
                SenderId = SenderId,
                ChatRoomID = chatRoom.Id,
                Content = messageContent
            };
            await _unitOfWork.Messages.CreateAsync(privateMessage);
            await _unitOfWork.SaveAsync();

            await Clients.Group($"user-{recipientUserId}").SendAsync("ReceiveMessage", new
            {
                message = messageContent,
                messageId = privateMessage.Id,
                displayTime = DateTime.UtcNow.ToString("MMM dd, yyyy 'at' hh:mm tt"),
                userName = Sender.UserName,
                //userImage = string.IsNullOrEmpty(Sender.ImagePath) ? "" : Sender.ImagePath,
            });  
        }
        public async Task SendGroupMessage(string messageContent)
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var groupMessage = new Message
            {
                SenderId = userId,
                ChatRoomID = 1,
                Content = messageContent
            };
            await _unitOfWork.Messages.CreateAsync(groupMessage);
            await _unitOfWork.SaveAsync();

            await Clients.Group("MomsGroupChat").SendAsync("ReceiveGroupMessage", new
            {
                message = messageContent,
                messageId = groupMessage.Id,
                displayTime = DateTime.UtcNow.ToString("MMM dd, yyyy 'at' hh:mm tt"),
                userName = user.UserName,
                //userImage = string.IsNullOrEmpty(user.ImagePath) ? "" : user.ImagePath,
            });
        }
        public async Task JoinGroup()
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            bool alreadyExist = await _unitOfWork.UserChatRooms.AnyAsync(u => u.ChatRoomId == 1 && u.UserId == userId);
            if (!alreadyExist)
            {
                UserChatRoom UserChatRoom = new UserChatRoom
                {
                    ChatRoomId = 1,
                    UserId = userId
                };
                await _unitOfWork.UserChatRooms.CreateAsync(UserChatRoom);
                await _unitOfWork.SaveAsync();
                string message = $"{user.UserName} joined the GroupChat";
                await Clients.Group("MomsGroupChat").SendAsync("UserJoined", message);
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, "MomsGroupChat");
        }
        public async Task LeftGroup()
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            bool alreadyExist = await _unitOfWork.UserChatRooms.AnyAsync(u => u.ChatRoomId == 1 && u.UserId == userId);
            if (alreadyExist)
            {
                var userLeft = await _unitOfWork.UserChatRooms.FirstOrDefaultAsync(u => u.ChatRoomId == 1 && u.UserId == userId);
                await _unitOfWork.UserChatRooms.DeleteAsync(userLeft);
                await _unitOfWork.SaveAsync();
                string message = $"{user.UserName} Left the GroupChat";
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