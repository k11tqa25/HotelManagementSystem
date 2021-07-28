using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Extensions;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Services
{
    public class CustomerService : EFService<Customer, CustomerRequestModel, CustomerResponseModel>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, ICustomerMapper customerMapper): base(customerRepository, customerMapper)
        {
            _customerRepository = customerRepository;
        }
        private CustomerDetailsResponseModel ToDetailModel(Customer c)
        {
            var customerDetails = new CustomerDetailsResponseModel()
            {
                Id = c.Id,
                Name = c.CNAME,
                Email = c.EMAIL,
                Address = c.ADDRESS,
                PhoneNumber = c.PHONE,
                TotalPerson = c.TOTALPERSONS.GetValueOrDefault(),
                CheckInDate = c.CHECKIN.GetValueOrDefault(),
                Advance = c.ADVANCE.GetValueOrDefault(),
                BookingDays = c.BOOKINGDAYS.GetValueOrDefault(),
                RoomNumber = c.ROOMNO.GetValueOrDefault(),
                RoomType = c.Room.RoomType.RTDESC,
            };
            customerDetails.RoomServices = new List<ApplicationCore.Models.RoomService>();
            foreach (var s in c.Room.Services)
            {
                customerDetails.RoomServices.Add(new ApplicationCore.Models.RoomService()
                {
                    ServiceName = s.SDESC,
                    Amount = s.AMOUNT.GetValueOrDefault()
                });
            }

            return customerDetails;
        }

        public async Task<CustomerDetailsResponseModel> GetCustomerDetailsByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerDetailsByIdAsync(id);
            if (customer == null) return null;
            return ToDetailModel(customer);
        }

        public async Task<List<CustomerDetailsResponseModel>> ListAllWithDetailsAsync()
        {
            var customers = await _customerRepository.ListAllWithDetailsAsync();
            if (customers == null) return null;
            var responses = new List<CustomerDetailsResponseModel>();
            foreach (var c in customers)
            {
                responses.Add(ToDetailModel(c));
            }
            return responses;
        }
    }
}
