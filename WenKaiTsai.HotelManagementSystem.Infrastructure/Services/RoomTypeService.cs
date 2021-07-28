using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Extensions;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Services
{
    public class RoomTypeService : EFService<RoomType, RoomTypeRequestModel, RoomTypeResponseModel>, IRoomTypeService
    {

        public RoomTypeService(IRoomTypeRepository repository, IRoomTypeMapper mapper) : base(repository, mapper)
        {
        }
    }
}
