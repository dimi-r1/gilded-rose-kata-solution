namespace GildedRoseTests.Constants;

public static class ItemNames
{
    // Standard items (decrease in quality)
    public const string DexterityVest = "+5 Dexterity Vest";
    public const string Elixir = "Elixir of the Mongoose";
    public const string StandardItem = "Regular Item"; // used for proving we don't rely on specific standard items.

    // Quality increasing items
    public const string AgedBrie = "Aged Brie";

    // Threshold-based quality items
    public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";

    // Immutable items
    public const string Sulfuras = "Sulfuras, Hand of Ragnaros";

    // Double degradation items
    public const string ConjuredManaCake = "Conjured Mana Cake";
    public const string AlternativeConjuredItem = "Conjured Health Potion";
}