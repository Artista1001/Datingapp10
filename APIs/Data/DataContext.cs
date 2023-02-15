using APIs.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIs.Data
{
    //Datacontext and DbContex are service in our application
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Dbset represent table name Users inside our Database
        public DbSet<AppUser> Users { get; set; }
    }
}
