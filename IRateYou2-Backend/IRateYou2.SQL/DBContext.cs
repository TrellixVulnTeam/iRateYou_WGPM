using Microsoft.EntityFrameworkCore;
using IRateYou2.Core.Models;

namespace IRateYou2.SQL
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}