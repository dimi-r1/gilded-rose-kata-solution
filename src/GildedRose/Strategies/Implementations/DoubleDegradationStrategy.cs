using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies.Implementations;

/// <summary>
/// Strategy for conjured items that degrade twice as fast as normal items before and after expiration.
/// </summary>
public class DoubleDegradationStrategy : BaseItemUpdateStrategy
{
    protected override void UpdateQualityBeforeExpiration(Item item)
    {
        DecreaseQualityTwice(item);
    }
    
    protected override void UpdateQualityAfterExpiration(Item item)
    {
        if (!IsExpired(item)) return;
        
        DecreaseQualityTwice(item);
    }

    private static void DecreaseQualityTwice(Item item)
    {
        switch (item.Quality)
        {
            case > Constants.Quality.MinQualityForDoubleDecrease:
                item.Quality -= Constants.Quality.DoubleDecrease;
                break;
            case > Constants.Quality.MinQuality:
                item.Quality = Constants.Quality.MinQuality;
                break;
        }
    }
}