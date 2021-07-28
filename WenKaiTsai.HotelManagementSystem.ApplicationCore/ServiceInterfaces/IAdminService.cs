using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface IAdminService
    {
        Task<AdminRegisterResponseModel> RegisterUserAsync(AdminRegisterRequestModel requestModel);

        Task<AdminLoginResponseModel> LoginAsync(AdminLoginRequestModel requestModel);

        Task<AdminLoginResponseModel> GetAdminByIdAsync(int id);

    }
}
