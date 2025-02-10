using Microsoft.EntityFrameworkCore;
using TasksCreator.Models;

namespace TasksCreator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
