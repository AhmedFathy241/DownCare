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
        public IGenricRepository<Article> Articles {  get; private set; }

        public IGenricRepository<Feedback> Feedbacks { get; private set; }

        public IGenricRepository<Report> Reports { get; private set; }

        public IGenricRepository<Child> Children { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Articles = new GenericRepository<Article>(_appDbContext);
            Feedbacks = new GenericRepository<Feedback>(_appDbContext);
            Reports = new GenericRepository<Report>(_appDbContext);
            Children = new GenericRepository<Child>(_appDbContext);
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
