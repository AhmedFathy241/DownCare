using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Infrastructure.Data;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.Services
{
    public class ChildService : IChildService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public ChildService(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<bool> CreateChildAsync(string UserId, ChildDTO child)
        {
            var existingChild = _unitOfWork.Children.FindAsync(c => c.MomID == UserId);
            if (existingChild != null)
                return false;
            Child newChild = new Child();
            newChild.Name = child.ChildName;
            newChild.Age = child.Age;
            newChild.DiagnosisDate = child.DiagnosisDate;
            newChild.Gender = child.Gneder;
            newChild.MomID = UserId;
            Child Model = await _unitOfWork.Children.CreateAsync(newChild);
            await _unitOfWork.SaveAsync();
            return true;
        }

        //public async Task<ChildDTO> ReadChild(string UserId)
        //{
        //    Child childfromDb = await _context.Users.Include(c=>c.)
        //    //ChildDTO child =  
        //}
    }
}
