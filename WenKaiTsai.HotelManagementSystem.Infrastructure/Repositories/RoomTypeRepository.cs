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
    public class RoomTypeRepository: EFRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementSystemDbContext dbContext): base(dbContext)
        {

        }
    }
}
