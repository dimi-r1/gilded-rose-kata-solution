using GildedRoseKata.Strategies;

namespace GildedRoseKata.Planning;

public interface IItemUpdateStrategyPlanner
{
    /// <summary>
    /// Gets the appropriate strategy for updating an item
    /// </summary>
    IItemUpdateStrategy GetStrategyFor(Item item);
}