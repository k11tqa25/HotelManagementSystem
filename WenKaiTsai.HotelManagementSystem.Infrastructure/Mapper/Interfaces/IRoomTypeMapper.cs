using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces
{
    public interface IRoomTypeMapper : IMapper<RoomType, RoomTypeRequestModel, RoomTypeResponseModel>
    {
    }
}
