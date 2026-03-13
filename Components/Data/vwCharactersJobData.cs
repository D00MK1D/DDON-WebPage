using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDON_WebPage.Components.Data
{
    [Keyless]
    public class vwCharactersJobData
    {
        [Column("char_id")]
        public int charId { get; set; }

        [Column("player_id")]
        public int playerId { get; set; }
        
        [Column("char_first_name")]
        public string charFirstName { get; set; } = string.Empty;

        [Column("char_last_name")]
        public string charLastName { get; set; } = string.Empty;

        [Column("job_id")]
        public int jobId { get; set; }
        
        [Column("job_level")]
        public int jobLevel { get; set; }
    }
}