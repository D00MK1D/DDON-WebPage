using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DDON_WebPage.Components.Data
{
    public class Item
    {
        [Column("item_uid")]
        public string item_Uid { get; set; }

        [Key]
        [Required]
        [Column("character_id")]
        public int charId { get; set; }

        [Column("storage_type")]
        public int storageType { get; set; }

        [Column("slot_no")]
        public int slotNumber { get; set; }

        [Column("item_id")]
        public int itemId { get; set; }

        [Column("item_num")]
        public int itemQuant { get; set; }

        [Column("safety")]
        public int safety { get; set; }

        [Column("color")]
        public int color { get; set; }

        [Column("plus_value")]
        public int plusValue { get; set; }

        [Column("equip_points")]
        public int equipPoints { get; set; }
    }

    public class ItemJson
    {
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("icon")]
        public Icon Icon { get; set; }
    }

    public class Icon
    {
        [JsonPropertyName("icon_id")]
        public int IconId { get; set; }
    }
}
