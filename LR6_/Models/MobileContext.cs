using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace LR6_.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
