using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceApi.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _context;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
