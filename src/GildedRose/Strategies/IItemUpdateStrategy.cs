namespace GildedRoseKata.Strategies;

public interface IItemUpdateStrategy
{
    /// <summary>
    /// Updates the quality and sellIn values of an item
    /// </summary>
    void UpdateQuality(Item item);
}