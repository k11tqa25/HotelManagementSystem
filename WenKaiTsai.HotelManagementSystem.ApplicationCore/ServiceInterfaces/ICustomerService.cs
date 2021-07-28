using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface ICustomerService: IAsyncService<CustomerRequestModel, CustomerResponseModel>
    {
        public Task<List<CustomerDetailsResponseModel>> ListAllWithDetailsAsync();
        public Task<CustomerDetailsResponseModel> GetCustomerDetailsByIdAsync(int id);
    }
}
