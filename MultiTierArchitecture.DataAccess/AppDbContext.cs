using Microsoft.EntityFrameworkCore;
using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.DataAccess
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }
    }

}