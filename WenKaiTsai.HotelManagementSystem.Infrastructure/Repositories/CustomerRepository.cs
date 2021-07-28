using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Data;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Repositories
{
    public class CustomerRepository: EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementSystemDbContext dbContext): base(dbContext)
        {

        }
        public async Task<Customer> GetCustomerDetailsByIdAsync(int id)
        {
            var customer = await _dbContext.Customers.Where(c => c.Id == id)
                                                                                                .Include(c => c.Room).ThenInclude(r => r.RoomType)
                                                                                                .Include(c => c.Room).ThenInclude(r => r.Services)
                                                                                                .FirstOrDefaultAsync();
            return customer;
        }


        public async Task<List<Customer>> ListAllWithDetailsAsync()
        {
            var customers = await _dbContext.Customers.Include(c => c.Room).ThenInclude(r => r.RoomType)
                                                                                                 .Include(c => c.Room).ThenInclude(r => r.Services)
                                                                                                 .ToListAsync();
            return customers;
        }

    }
}
