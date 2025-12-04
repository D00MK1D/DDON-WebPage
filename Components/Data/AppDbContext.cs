using Microsoft.EntityFrameworkCore;

namespace DDON_WebPage.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Account> account { get; set; }
        public DbSet<Character> ddon_character { get; set; }
        public DbSet<vwCharactersJobData> vw_characters_job_data { get; set; } 
    }
}