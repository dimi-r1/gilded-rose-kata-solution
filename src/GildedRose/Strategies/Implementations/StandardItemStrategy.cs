using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies.Implementations;

/// <summary>
/// Strategy for standard items that degrade in quality over time
/// </summary>
public class StandardItemStrategy : BaseItemUpdateStrategy
{
    protected override void UpdateQualityBeforeExpiration(Item item)
    {
        DecreaseQuality(item);
    }

    protected override void UpdateQualityAfterExpiration(Item item)
    {
        if (!IsExpired(item)) return;
        DecreaseQuality(item);
    }
}