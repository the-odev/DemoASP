using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDataContext
    {
         DbSet<User> Users { get; set; }

         DbSet<Document> Documents { get; set; }

         DbSet<GameOfThrone> GameOfThrones { get; set; }

        DbSet<Episode> Episodes { get; set; }

         int SaveChanges();
    }
}