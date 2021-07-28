using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces
{
    public interface ICustomerRepository: IAsyncRepository<Customer>
    {
        public Task<List<Customer>> ListAllWithDetailsAsync();
        public Task<Customer> GetCustomerDetailsByIdAsync(int id);
    }
}
