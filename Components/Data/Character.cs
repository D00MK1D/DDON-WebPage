using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDON_WebPage.Components.Data
{
    public class Character
    {
        [Key]
        [Required]
        [Column("character_id")]
        public int characterId { get; set; }

        [Column("character_common_id")]
        public int characterCommonId { get; set; }
        
        [Column("account_id")]
        public int accountId { get; set; }
        
        [Column("version")]
        public int version { get; set; }

        [Column("first_name")]
        public string firstName { get; set; } = string.Empty;

        [Column("last_name")]
        public string lastName { get; set; } = string.Empty;

        [Column("created")]
        public DateTime createdAt { get; set; }

        [Column("my_pawn_slot_num")]
        public int myPawnSlotNum { get; set; }

        [Column("rental_pawn_slot_num")]
        public int rentalPawnSlotNum { get; set; }

        [Column("hide_equip_head_pawn")]
        public bool hideEquipHeadPawn { get; set; }

        [Column("hide_equip_lantern_pawn")]
        public bool hideEquipLanternPawn { get; set; }

        [Column("arisen_profile_share_range")]
        public int arisenProfileShareRange { get; set; }

        [Column("fav_warp_slot_num")]
        public int favWarpSlotNum { get; set; }

        [Column("max_bazaar_exhibits")]
        public int maxBazaarExhibits { get; set; }

        [Column("partner_pawn_id")]
        public int partnerPawnId { get; set; }

        [Column("game_mode")]
        public int gameMode { get; set; }
    }
}
