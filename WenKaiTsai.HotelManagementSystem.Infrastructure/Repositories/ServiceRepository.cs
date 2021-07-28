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
    public class ServiceRepository: EFRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HotelManagementSystemDbContext dbContext): base(dbContext)
        {

        }
    }
}
