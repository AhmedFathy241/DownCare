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
        public IGenricRepository<Article> Articles { get; }
        public IGenricRepository<Feedback> Feedbacks { get; }
        public IGenricRepository<Report> Reports { get; }
        public IGenricRepository<Child> Children { get; }
        public Task<int> SaveAsync();
    }
}
