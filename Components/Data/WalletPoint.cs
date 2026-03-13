using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDON_WebPage.Components.Data
{
    public class WalletPoint
    {
        [Key]
        [Column("character_id")]
        public int charId { get; set; }

        [Column("type")]
        public int walletType { get; set; }

        [Column("value")]
        public int walletValue { get; set; }
    }
}