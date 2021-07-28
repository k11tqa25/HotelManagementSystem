using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Extensions;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Services
{
    public class EFService<TEntity, TRequest, TResponse>: IAsyncService<TRequest, TResponse>
        where TEntity: class
        where TRequest : class 
        where TResponse: class
    {
        private IMapper<TEntity, TRequest, TResponse> _mapper;
        private IAsyncRepository<TEntity> _repository;

        public EFService(IAsyncRepository<TEntity> repository, IMapper<TEntity, TRequest, TResponse> mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TResponse> AddAsync(TRequest requestModel)
        {
            var response = await _repository.AddAsync(_mapper.ToEntity(requestModel));

            return _mapper.ToResponse(response);
        }

        public async Task<TResponse> DeleteByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            var response = await _repository.DeleteAsync(entity);
            return _mapper.ToResponse(response);
        }

        public async Task<List<TResponse>> FilterAsync<T>(Expression<Func<T, bool>> filter)
        {
            var entities = await _repository.ListAsync(filter as Expression<Func<TEntity, bool>>);
            if (entities == null) return null;
            var reponses = entities.ConvertAll(e => _mapper.ToResponse(e));
            return reponses;
        }

        public async Task<TResponse> GetByIdAsync(int id)
        {
            var response =  await _repository.GetByIdAsync(id);
            if (response == null) return null;
            return _mapper.ToResponse(response);
        }

        public async Task<List<TResponse>> ListAllAsync()
        {
            var entities = await _repository.ListAllAsync();
            if (entities == null) return null;
            var reponses = entities.ConvertAll(e => _mapper.ToResponse(e));
            return reponses;
        }

        public async Task<TResponse> UpdateAsync(TRequest requestModel)
        {
            var response = await _repository.UpdateAsync(_mapper.ToEntity(requestModel));
            return _mapper.ToResponse(response);
        }

        public async Task<TResponse> UpdateWithIdAsync(int id, TRequest requestModel)
        {
            var response = await _repository.UpdateAsync(_mapper.ToEntityWithId(id, requestModel));
            if (response == null) return null;
            return _mapper.ToResponse(response);
        }
    }
}
