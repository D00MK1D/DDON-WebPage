namespace DDON_WebPage.Data
{
    public class ItemList
    {
        public int ItemId { get; set; }
        public string Category { get; set; } = "";
        public int Price { get; set; }
        public int StackMax { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; } = "";
        public string Subcategory { get; set; } = "";
        public int Level { get; set; }
        public string Jobs { get; set; } = "";
        public int Crests { get; set; }
        public int Quality { get; set; }
        public string Gender { get; set; } = "";
    }
}