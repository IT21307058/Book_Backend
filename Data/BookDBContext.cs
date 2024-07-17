using BMS.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BMS.Data
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
