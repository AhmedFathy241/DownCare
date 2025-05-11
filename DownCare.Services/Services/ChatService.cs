using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Infrastructure.Data;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace DownCare.Services.Services
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _dbcontext;
        public ChatService (IUnitOfWork unitOfWork, AppDbContext dbcontext)
        {
            _unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
        }
        public async Task<APIResponse> ReadAllChatRoomsAsync(string userId, string baseURL)
        {
            var chatRooms = await _dbcontext.ChatRooms
                 .Where(cr => cr.UserChatRooms.Any(ucr => ucr.UserId == userId))
                 .Select(cr => new ChatRoomDTO
                 {
                     Id = cr.Id,
                     Name = cr.IsGroup ? cr.Name : cr.UserChatRooms
                         .Where(ucr => ucr.UserId != userId)
                         .Select(ucr => ucr.User.UserName)
                         .FirstOrDefault() ?? "Unknown",
                     ImageUrl = cr.IsGroup ? cr.UserChatRooms
                         .Where(ucr => ucr.UserId != userId)
                         .Select(ucr => ucr.User.ImagePath)
                         .FirstOrDefault() : cr.UserChatRooms
                         .Where(ucr => ucr.UserId != userId)
                         .Select(ucr => ucr.User.ImagePath)
                         .FirstOrDefault() ?? ""
                 })
                 .ToListAsync();
            return new APIResponse { Model = chatRooms };
        }
        public async Task<IEnumerable<MessagesDTO>> ReadMessagesAsync(int ChatRoomId, string baseURL)
        {
            var groupMessages = await _dbcontext.Messages
                .Where(m => m.ChatRoomID == ChatRoomId && m.IsDelete == false)
                .OrderBy(m => m.DateTime)
                .Select(gm => new MessagesDTO
                {
                    Id = gm.Id,
                    Message = gm.Content,
                    DateTime = gm.DateTime,
                    DisplayTime = gm.DateTime.ToString("MMM dd, yyyy 'at' hh:mm tt"),
                    UserName = gm.AppUser.UserName,
                    UserImageURL = string.IsNullOrEmpty(gm.AppUser.ImagePath) ? "" : baseURL + gm.AppUser.ImagePath
                })
                .ToListAsync();
            return groupMessages;
        }
        public async Task<APIResponse> DeleteMessageAsync(int messageId)
        {
            var Check = await _dbcontext.Messages.AnyAsync(m => m.Id == messageId);
            if (!Check)
            {
                return new APIResponse { IsSuccess = false, Message = "Message not found" };
            }
            var message = await _dbcontext.Messages.FindAsync(messageId);
            message.IsDelete = true;
            _dbcontext.Messages.Update(message);
            await _dbcontext.SaveChangesAsync();
            return new APIResponse { IsSuccess = true, Message = "Message deleted successfully" };
        }
        public async Task <APIResponse> ReadGroupMembersAsync(string baseURL)
        {
            var groupMembers = await _dbcontext.UserChatRooms
                .Include(u => u.User)
                .Where(u => u.ChatRoomId == 1)
                .Select(gm => new
                {
                    userName = gm.User.UserName,
                    userImageURL = string.IsNullOrEmpty(gm.User.ImagePath) ? "" : baseURL + gm.User.ImagePath
                })
                .ToListAsync();
            return new APIResponse { Model = groupMembers };
        }

        public async Task<ChatRoom> GerOrCreateChatRoomAsync(string SenderId, string recipientUserId)
        {
            var chatRoom = await _dbcontext.ChatRooms
                .Include(cr => cr.UserChatRooms)
                .FirstOrDefaultAsync(cr => cr.UserChatRooms.Any(ucr => ucr.UserId == SenderId) &&
                                          cr.UserChatRooms.Any(ucr => ucr.UserId == recipientUserId));

            if (chatRoom != null)
            {
                return chatRoom; // Return the existing chat room
            }

            // Create a new chat room
            chatRoom = new ChatRoom
            {
                UserChatRooms = new List<UserChatRoom>
            {
                new UserChatRoom { UserId = SenderId },
                new UserChatRoom { UserId = recipientUserId }
            }
            };
            await _unitOfWork.ChatRooms.CreateAsync(chatRoom);
            await _unitOfWork.SaveAsync();
            return chatRoom;
        }
        public Task<APIResponse> JoinGroupAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}