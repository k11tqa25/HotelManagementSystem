using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface ICurrentAdmin
    {
        int Id { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string Name { get; }
    }
}
