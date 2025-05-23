﻿using DownCare.Core.IRepositories;
using DownCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DownCare.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenricRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<T> CreateAsync(T model)
        {
            await _appDbContext.Set<T>().AddAsync(model);
            return model;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var Data = await _appDbContext.Set<T>().ToListAsync();
            return Data;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task <bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>().AnyAsync(predicate);
        }
        public async Task DeleteAsync(T model)
        {
            _appDbContext.Set<T>().Remove(model);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
