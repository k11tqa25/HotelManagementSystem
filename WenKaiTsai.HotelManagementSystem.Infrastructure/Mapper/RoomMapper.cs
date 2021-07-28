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
    public class RoomMapper : IRoomMapper
    {
        public Room ToEntity(RoomRequestModel request)
        {
            return new Room()
            {
                RTCODE = request.RoomTypeId,
                STATUS = request.Status
            };
        }

        public Room ToEntityWithId(int id, RoomRequestModel request)
        {
            return new Room()
            {
                Id = id,
                RTCODE = request.RoomTypeId,
                STATUS = request.Status
            };
        }

        public RoomResponseModel ToResponse(Room entity)
        {
            return new RoomResponseModel()
            {
                Id = entity.Id,
                RoomTypeId = entity.RTCODE.GetValueOrDefault(),
                Status = entity.STATUS.GetValueOrDefault(),
                RoomType = entity.RoomType.RTDESC
            };
        }
    }
}
