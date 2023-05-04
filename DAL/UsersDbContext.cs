using DAL.Configs;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class UsersDbContext : DbContext, IUsersDBcontext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
