using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces
{
    public interface IMapper<TEntity, TRequest, TResponse>
        where TEntity: class
        where TRequest: class
        where TResponse: class
    {
        TEntity ToEntity(TRequest request);

        TEntity ToEntityWithId(int id, TRequest request);

        TResponse ToResponse(TEntity entity);
    }
}
