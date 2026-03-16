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
        public DbSet<WalletPoint> ddon_wallet_point { get; set; } 

        //TODO: Make a view to join additional info like crests
        public DbSet<Item> ddon_storage_item { get; set; }
        //And play the fucking game to better understand what would be useful to show

    }
}