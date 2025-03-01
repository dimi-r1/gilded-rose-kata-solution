namespace GildedRoseKata.Strategies.Base;

public abstract class BaseItemUpdateStrategy : IItemUpdateStrategy
{
    public void UpdateQuality(Item item)
    {
        UpdateQualityBeforeExpiration(item);
        UpdateSellIn(item);
        UpdateQualityAfterExpiration(item);
    }

    protected abstract void UpdateQualityBeforeExpiration(Item item);

    protected abstract void UpdateQualityAfterExpiration(Item item);

    protected virtual void UpdateSellIn(Item item)
    {
        item.SellIn -= Constants.SellIn.DefaultDecrease;
    }

    protected static void IncreaseQuality(Item item)
    {
        if (item.Quality < Constants.Quality.MaxQuality)
        {
            item.Quality += Constants.Quality.DefaultIncrease;
        }
    }

    protected static void DecreaseQuality(Item item)
    {
        if (item.Quality > Constants.Quality.MinQuality)
        {
            item.Quality -= Constants.Quality.DefaultDecrease;
        }
    }

    protected static bool IsExpired(Item item) => item.SellIn < Constants.SellIn.Expired;
}