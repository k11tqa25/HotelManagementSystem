using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface IAsyncService<Tin, Tout> 
        where Tin: class 
        where Tout: class
    {
        Task<Tout> AddAsync(Tin requestModel);
        Task<Tout> UpdateWithIdAsync(int id, Tin requestModel);
        Task<Tout> DeleteByIdAsync(int id);
        Task<List<Tout>> ListAllAsync();
        Task<Tout> GetByIdAsync(int id);
        Task<List<Tout>> FilterAsync<T>(Expression<Func<T, bool>> filter);
    }
}
