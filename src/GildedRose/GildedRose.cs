using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    // We could rename to _items, but we are not allowed to modify this property.
    // Readme: We are allowed to make this static
    IList<Item> Items;

    public GildedRose(IList<Item> items)
    {
        Items = items;
    }

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
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Quality <= 0) return; // Quality is never negative

            // The quality of legendary items doesn't change.
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.Quality -= 1;
            }
        }
        else // Handle items whose quality increases.
        {
            if (item.Quality >= 50) return; // Quality is never more than 50

            item.Quality += 1; // Increasing quality items gain 1 quality

            // Backstage passes increase in quality as the concert approaches
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert") return;

            // Additional quality increase when 10 days or less remain
            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1; // +1 more (total +2) when 10 days or less
                }
            }

            if (item.SellIn >= 6) return;

            // Additional quality increase when 5 days or less remain
            if (item.Quality < 50)
            {
                item.Quality += 1; // +1 more (total +3) when 5 days or less
            }
        }
    }

    private static void UpdateItemSellIn(Item item)
    {
        // Legendary items (Sulfuras) don't have to be sold, so SellIn never changes
        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn -= 1; // Decrease sellIn for all non-legendary items
        }
    }

    private static void UpdateExpiredItemQuality(Item item)
    {
        if (item.SellIn >= 0) return; // Only process expired items (SellIn < 0)

        // Handle items whose quality decreases after expiration.
        if (item.Name != "Aged Brie")
        {
            // After concert, backstage passes have no value
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0; // More efficiently written as item.Quality = 0
            }
            // Standard items and Sulfuras
            else
            {
                if (item.Quality <= 0) return; // Maintain quality floor of 0

                // Legendary items (Sulfuras) never change quality
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality -= 1; // Second quality decrease for expired items (degrades twice as fast)
                }
            }
        }
        // Handle items whose quality increases after expiration.
        else
        {
            if (item.Quality < 50) // Maintain quality ceiling of 50
            {
                item.Quality += 1; // Second quality increase for expired Aged Brie (increases twice as fast)
            }
        }
    }
}