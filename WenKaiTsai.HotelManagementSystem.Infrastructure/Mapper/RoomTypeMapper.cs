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
    public class RoomTypeMapper : IRoomTypeMapper
    {
        public RoomType ToEntity(RoomTypeRequestModel request)
        {
            return new RoomType()
            {
                RTDESC = request.RoomType,
                RENT = request.Rent
            };
        }

        public RoomType ToEntityWithId(int id, RoomTypeRequestModel request)
        {
            return new RoomType()
            {
                Id = id,
                RTDESC = request.RoomType,
                RENT = request.Rent
            };
        }

        public RoomTypeResponseModel ToResponse(RoomType entity)
        {
            return new RoomTypeResponseModel()
            {
                Id = entity.Id,
                Rent = entity.RENT.GetValueOrDefault(),
                RoomType = entity.RTDESC
            };
        }
    }
}
