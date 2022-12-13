using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Plenti.Entities;
using System.Reflection.Metadata;

namespace Plenti.Data
{
    public class PlentiDbContext : DbContext
    {
        public PlentiDbContext(DbContextOptions<PlentiDbContext> options) : base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(a => a.Address)
            .WithOne(b => b.User)
            .HasForeignKey<Address>(e => e.UserId);
        }
    }

}
