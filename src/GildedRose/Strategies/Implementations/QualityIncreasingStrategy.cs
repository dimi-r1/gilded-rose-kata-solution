using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies.Implementations;

/// <summary>
/// Strategy for items that increase in quality over time (e.g., Aged Brie)
/// </summary>
public class QualityIncreasingStrategy : BaseItemUpdateStrategy
{
    protected override void UpdateQualityBeforeExpiration(Item item)
    {
        IncreaseQuality(item);
    }

    protected override void UpdateQualityAfterExpiration(Item item)
    {
        if (IsExpired(item))
        {
            IncreaseQuality(item);
        }
    }
}