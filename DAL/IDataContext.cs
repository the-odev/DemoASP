using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDataContext
    {
         DbSet<User> Users { get; set; }

         int SaveChanges();
    }
}