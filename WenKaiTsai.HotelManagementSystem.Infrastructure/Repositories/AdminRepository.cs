using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Data;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Repositories
{
    public class AdminRepository : EFRepository<Admin>, IAdminRepository
    {
        public AdminRepository(HotelManagementSystemDbContext dbContext): base(dbContext)
        {

        }
        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            return await _dbContext.Admins.FirstOrDefaultAsync(a => a.EMAIL == email);
        }
    }
}
