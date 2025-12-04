using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDON_WebPage.Components.Data
{
    [Keyless]
    public class vwCharactersJobData
    {
        [Column("player_name")]
        public string playerName { get; set; } = string.Empty;
        
        [Column("char_first_name")]
        public string charFirstName { get; set; } = string.Empty;

        [Column("char_last_name")]
        public string charLastName { get; set; } = string.Empty;

        [Column("job_id")]
        public uint jobId { get; set; }
        
        [Column("job_level")]
        public uint jobLevel { get; set; }
    }
}
