using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Data
{
    public class HotelManagementSystemDbContext : DbContext
    {
        public HotelManagementSystemDbContext(DbContextOptions<HotelManagementSystemDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }    
}
