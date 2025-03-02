using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies.Implementations;

/// <summary>
/// Strategy for immutable items that never change in quality or sell-by date (e.g., Sulfuras)
/// </summary>
public class ImmutableItemStrategy : BaseItemUpdateStrategy
{
    protected override void UpdateQualityBeforeExpiration(Item item)
    {
    }

    protected override void UpdateQualityAfterExpiration(Item item)
    {
    }

    protected override void UpdateSellIn(Item item)
    {
    }
}