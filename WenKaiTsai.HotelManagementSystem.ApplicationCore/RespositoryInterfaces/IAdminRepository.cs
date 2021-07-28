using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces
{
    public interface IAdminRepository: IAsyncRepository<Admin>
    {
        Task<Admin> GetAdminByEmailAsync(string email);
    }
}
