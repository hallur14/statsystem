using Microsoft.EntityFrameworkCore;
using SimpleStatsApi.Models.EntityModels;

namespace SimpleStatsApi.Repositories
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set;}
    }
}