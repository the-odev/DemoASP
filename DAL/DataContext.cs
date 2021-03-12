using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TU24MN5\SQLEXPRESS;Database=demoASP2;Trusted_Connection=True;");
        }
    }
}