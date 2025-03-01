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
            case > 1:
                item.Quality -= 2;
                break;
            case > 0:
                item.Quality = 0;
                break;
        }
    }
}