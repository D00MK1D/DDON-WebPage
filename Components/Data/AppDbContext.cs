using Microsoft.EntityFrameworkCore;
using System.Security;

namespace DDON_WebPage.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> account { get; set; }

    }
}