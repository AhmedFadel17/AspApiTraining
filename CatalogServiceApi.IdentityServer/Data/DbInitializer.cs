using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CatalogServiceApi.IdentityServer.Data
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private readonly DataSeeder _dataSeeder;

        public DbInitializer(AppDbContext context, DataSeeder dataSeeder)
        {
            _context = context;
            _dataSeeder = dataSeeder;
        }

        public async Task InitializeAsync()
        {
            if (_context.Database.IsSqlServer())
            {
                // Apply any pending migrations
                await _context.Database.MigrateAsync();
            }

            // Seed data into the database
            await _dataSeeder.SeedDataAsync();
        }

    }
}
