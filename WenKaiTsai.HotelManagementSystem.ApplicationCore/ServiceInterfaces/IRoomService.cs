using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface IRoomService: IAsyncService<RoomRequestModel, RoomResponseModel>
    {
    }
}
