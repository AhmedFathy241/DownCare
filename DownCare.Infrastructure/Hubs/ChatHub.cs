using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Infrastructure.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _dbcontext;

        public ChatHub(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, AppDbContext dbcontext)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
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
            var chatRoom = await GetOrCreateChatRoomAsync(SenderId, recipientUserId);
            var message = new Message
            {
                SenderId = SenderId,
                ChatRoomID = chatRoom.Id,
                Content = content,
                IsRead = false
            };
            await _unitOfWork.Messages.CreateAsync(message);

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
        private async Task<ChatRoom> GetOrCreateChatRoomAsync(string user1Id, string user2Id)
        {
            // Find an existing chat room between the two users
            var chatRoom = await _dbcontext.ChatRooms
                .Include(cr => cr.UserChatRooms)
                .FirstOrDefaultAsync(cr => cr.UserChatRooms.Any(ucr => ucr.UserId == user1Id) &&
                                          cr.UserChatRooms.Any(ucr => ucr.UserId == user2Id));

            if (chatRoom != null)
            {
                return chatRoom; // Return the existing chat room
            }

            // Create a new chat room
            chatRoom = new ChatRoom
            {
                UserChatRooms = new List<UserChatRoom>
            {
                new UserChatRoom { UserId = user1Id },
                new UserChatRoom { UserId = user2Id }
            }
            };
            _unitOfWork.ChatRooms.CreateAsync(chatRoom);
            return chatRoom;
        }
        //var sender = await _userManager.FindByIdAsync(SenderId);
        //var recipient = await _userManager.FindByIdAsync(recipientUserId);
        //if (recipient == null || string.IsNullOrEmpty(recipient.ConnectionID))
        //{
        //    throw new InvalidOperationException("Recipient is not connected.");
        //}
        //var ChatRoom = new ChatRoom
        //{
        //    CreatedAt = DateTime.Now,
        //    ch
        //};
        //var message = new Message
        //{
        //    SenderId = SenderId,
        //    ChatRoomID = ChatRoom.Id,
        //    Content = content,
        //    Timestamp = DateTime.UtcNow,
        //    IsRead = false
        //};
        //_dbContext.Messages.Add(message);
        //await _dbContext.SaveChangesAsync();

    }
    
}
