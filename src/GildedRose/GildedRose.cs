using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    // We could rename to _items, but we are not allowed to modify this property.
    // Readme: We are allowed to make this static
    IList<Item> Items = items;

    // Readme: We are allowed to make this static
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            UpdateItemQuality(item);
            UpdateItemSellIn(item);
            UpdateExpiredItemQuality(item);
        }
    }

    private static void UpdateItemQuality(Item item)
    {
        // Handle items whose quality decreases.
        if (item.Name != Constants.ItemNames.AgedBrie && 
            item.Name != Constants.ItemNames.BackstagePasses)
        {
            if (item.Quality <= Constants.Quality.MinQuality) return; // Quality is never negative

            // The quality of legendary items doesn't change.
            if (item.Name != Constants.ItemNames.Sulfuras)
            {
                item.Quality -= Constants.Quality.DefaultDecrease;
            }
        }
        else // Handle items whose quality increases.
        {
            if (item.Quality >= Constants.Quality.MaxQuality) return; // Quality is never more than 50

            item.Quality += Constants.Quality.DefaultIncrease; // Increasing quality items gain 1 quality

            // Backstage passes increase in quality as the concert approaches
            if (item.Name != Constants.ItemNames.BackstagePasses) return;

            // Additional quality increase when 10 days or less remain
            if (item.SellIn < Constants.SellIn.ThresholdItemFirstThreshold)
            {
                if (item.Quality < Constants.Quality.MaxQuality)
                {
                    item.Quality += Constants.Quality.DefaultIncrease; // +1 more (total +2) when 10 days or less
                }
            }

            if (item.SellIn >= Constants.SellIn.ThresholdItemSecondThreshold) return;

            // Additional quality increase when 5 days or less remain
            if (item.Quality < Constants.Quality.MaxQuality)
            {
                item.Quality += Constants.Quality.DefaultIncrease; // +1 more (total +3) when 5 days or less
            }
        }
    }

    private static void UpdateItemSellIn(Item item)
    {
        // Legendary items (Sulfuras) don't have to be sold, so SellIn never changes
        if (item.Name != Constants.ItemNames.Sulfuras)
        {
            item.SellIn -= Constants.SellIn.DefaultDecrease; // Decrease sellIn for all non-legendary items
        }
    }

    private static void UpdateExpiredItemQuality(Item item)
    {
        if (item.SellIn >= Constants.SellIn.Expired) return; // Only process expired items (SellIn < 0)

        // Handle items whose quality decreases after expiration.
        if (item.Name != Constants.ItemNames.AgedBrie)
        {
            // After concert, backstage passes have no value
            if (item.Name == Constants.ItemNames.BackstagePasses)
            {
                item.Quality = Constants.Quality.MinQuality; // Sets quality to 0
            }
            // Standard items and Sulfuras
            else
            {
                if (item.Quality <= Constants.Quality.MinQuality) return; // Maintain quality floor of 0

                // Legendary items (Sulfuras) never change quality
                if (item.Name != Constants.ItemNames.Sulfuras)
                {
                    item.Quality -= Constants.Quality.DefaultDecrease; // Second quality decrease for expired items (degrades twice as fast)
                }
            }
        }
        // Handle items whose quality increases after expiration.
        else
        {
            if (item.Quality < Constants.Quality.MaxQuality) // Maintain quality ceiling of 50
            {
                item.Quality += Constants.Quality.DefaultIncrease; // Second quality increase for expired Aged Brie (increases twice as fast)
            }
        }
    }
}