using DownCare.Core.Entities;
using DownCare.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenricRepository<Doctor> Doctors { get; }
        public IGenricRepository<Mom> Moms { get; }
        public IGenricRepository<Article> Articles { get; }
        public IGenricRepository<Feedback> Feedbacks { get; }
        public IGenricRepository<Child> Children { get; }
        public IGenricRepository<LinguisticsScore> LinguisticsScore { get; }
        public IGenricRepository<CommunicationScore> CommunicationScore { get; }
        public IGenricRepository<ActivityData> ActivityData { get; }
        public IGenricRepository<ChatRoom> ChatRooms { get; }
        public IGenricRepository<UserChatRoom> UserChatRooms { get; }
        public IGenricRepository<Message> Messages { get; }
        public Task<int> SaveAsync();
    }
}
