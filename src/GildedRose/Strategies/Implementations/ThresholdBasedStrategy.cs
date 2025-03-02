using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies.Implementations;

/// <summary>
/// Strategy for items whose quality changes based on SellIn thresholds (e.g., Backstage passes)
/// </summary>
public class ThresholdBasedStrategy : BaseItemUpdateStrategy
{
    protected override void UpdateQualityBeforeExpiration(Item item)
    {
        // Base increase
        IncreaseQuality(item);

        // Additional increase when 10 days or less
        if (item.SellIn < Constants.SellIn.ThresholdItemFirstThreshold)
        {
            IncreaseQuality(item);
        }

        // Additional increase when 5 days or less
        if (item.SellIn < Constants.SellIn.ThresholdItemSecondThreshold)
        {
            IncreaseQuality(item);
        }
    }

    protected override void UpdateQualityAfterExpiration(Item item)
    {
        if (!IsExpired(item)) return;
        
        // Quality drops to zero after the expiration.
        item.Quality = Constants.Quality.MinQuality;
    }
}