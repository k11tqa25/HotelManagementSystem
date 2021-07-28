using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper
{
    public class ServiceMapper : IServiceMapper
    {
        public Service ToEntity(ServiceRequestModel request)
        {
            return new Service()
            {
                SDESC = request.Service,
                SERVICEDATE = request.ServiceDate,
                AMOUNT = request.Amount,
                ROOMNO = request.RoomNumber
            };
        }

        public Service ToEntityWithId(int id, ServiceRequestModel request)
        {
            return new Service()
            {
                Id = id,
                SDESC = request.Service,
                SERVICEDATE = request.ServiceDate,
                AMOUNT = request.Amount,
                ROOMNO = request.RoomNumber
            };
        }

        public ServiceResponseModel ToResponse(Service entity)
        {
            return new ServiceResponseModel()
            {
                Id = entity.Id,
                Service = entity.SDESC,
                ServiceDate = entity.SERVICEDATE,
                Amount = entity.AMOUNT.GetValueOrDefault(),
                RoomNumber = entity.ROOMNO.GetValueOrDefault()
            };
        }
    }
}
