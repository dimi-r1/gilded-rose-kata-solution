using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies.Implementations;

/// <summary>
/// Strategy for immutable items that never change in quality or sell-by date (e.g., Sulfuras)
/// </summary>
public class ImmutableItemStrategy : BaseItemUpdateStrategy
{
    protected override void UpdateQualityBeforeExpiration(Item item)
    {
        // Do nothing - quality remains the same
    }

    protected override void UpdateQualityAfterExpiration(Item item)
    {
        // Do nothing - quality remains the same
    }

    protected override void UpdateSellIn(Item item)
    {
        // Do nothing - SellIn remains the same
    }
}