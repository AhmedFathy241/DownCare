using DownCare.Core.Entities;
using DownCare.Core.IRepositories;
using DownCare.Infrastructure.Data;
using DownCare.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IGenricRepository<Doctor> Doctors { get; private set; }
        public IGenricRepository<Mom> Moms { get; private set; }
        public IGenricRepository<Article> Articles {  get; private set; }
        public IGenricRepository<Feedback> Feedbacks { get; private set; }
        public IGenricRepository<Child> Children { get; private set; }
        public IGenricRepository<LinguisticsScore> LinguisticsScore { get; private set; }
        public IGenricRepository<CommunicationScore> CommunicationScore { get; private set; }
        public IGenricRepository<ActivityData> ActivityData { get; }
        public IGenricRepository<ChatRoom> ChatRooms { get; private set; }
        public IGenricRepository<UserChatRoom> UserChatRooms { get; private set; }
        public IGenricRepository<Message> Messages { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            Doctors = new GenericRepository<Doctor>(_appDbContext);
            Moms = new GenericRepository<Mom>(_appDbContext);
            Articles = new GenericRepository<Article>(_appDbContext);
            Feedbacks = new GenericRepository<Feedback>(_appDbContext);
            Children = new GenericRepository<Child>(_appDbContext);
            LinguisticsScore = new GenericRepository<LinguisticsScore>(_appDbContext);
            CommunicationScore = new GenericRepository<CommunicationScore>(_appDbContext);
            ActivityData = new GenericRepository<ActivityData>(_appDbContext);
            ChatRooms = new GenericRepository<ChatRoom>(_appDbContext);
            UserChatRooms = new GenericRepository<UserChatRoom>(_appDbContext);
            Messages = new GenericRepository<Message>(_appDbContext);
        }
        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
