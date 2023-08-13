using BookStore.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> BookItem { get; set; }
    }
}
