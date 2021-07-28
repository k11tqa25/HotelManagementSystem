using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Data;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Repositories
{
    public class RoomRepository: EFRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementSystemDbContext dbContext): base(dbContext)
        {

        }

        public override async Task<Room> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms.AsNoTracking().Where(r => r.Id == id).Include(r => r.RoomType).FirstOrDefaultAsync();
        }

        public override async Task<Room> AddAsync(Room entity)
        {
            var newEntity = await base.AddAsync(entity);
            if (newEntity == null) return null;
            return await _dbContext.Rooms.Where(r => r.Id == newEntity.Id).Include(r => r.RoomType).FirstOrDefaultAsync();
        }

        public override async Task<Room> UpdateAsync(Room entity)
        {
            _dbContext.Rooms.Update(entity);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Rooms.Where(r => r.Id == entity.Id).Include(r => r.RoomType).FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Room>> ListAllAsync()
        {
            return await _dbContext.Rooms.Include(r => r.RoomType).ToListAsync();
        }
        public override async Task<IEnumerable<Room>> ListAsync(Expression<Func<Room, bool>> filter)
        {
            return await _dbContext.Rooms.Include(r => r.RoomType).Where(filter).ToListAsync();
        }
    }
}
