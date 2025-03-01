namespace GildedRoseKata;

public static class Constants
{
    public static class ItemNames
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string DexterityVest = "+5 Dexterity Vest";
        public const string Elixir = "Elixir of the Mongoose";
        public const string ManaCake = "Mana Cake";
    }

    public static class ItemPrefixes
    {
        public const string Conjured = "Conjured";
    }
    
    public static class Quality
    {
        public const int MinQuality = 0;
        public const int MaxQuality = 50;
        public const int DefaultDecrease = 1;
        public const int DefaultIncrease = 1;
    }
    
    public static class SellIn
    {
        public const int Expired = 0;
        public const int ThresholdItemFirstThreshold = 11; // When <= 10 days
        public const int ThresholdItemSecondThreshold = 6; // When <= 5 days
        public const int DefaultDecrease = 1;
    }
}