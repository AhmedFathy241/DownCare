using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IChatService
    {
        Task<APIResponse> ReadAllChatRoomsAsync(string userId, string baseURL);
        Task<IEnumerable<MessagesDTO>> ReadMessagesAsync(int ChatRoomId, string baseURL);
        Task<APIResponse> DeleteMessageAsync(int messageId);
        Task<APIResponse> ReadGroupMembersAsync(string baseURL);

        Task<ChatRoom> GerOrCreateChatRoomAsync(string SenderId, string recipientUserId);
        Task<APIResponse> JoinGroupAsync(string userId);
    }
}