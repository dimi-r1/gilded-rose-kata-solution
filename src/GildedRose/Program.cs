using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    private const int DefaultDays = 30;

    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> Items = new List<Item>
        {
            new() { Name = Constants.ItemNames.DexterityVest, SellIn = 10, Quality = 20 },
            new() { Name = Constants.ItemNames.AgedBrie, SellIn = 2, Quality = 0 },
            new() { Name = Constants.ItemNames.Elixir, SellIn = 5, Quality = 7 },
            new() { Name = Constants.ItemNames.Sulfuras, SellIn = 0, Quality = 80 },
            new() { Name = Constants.ItemNames.Sulfuras, SellIn = -1, Quality = 80 },
            new()
            {
                Name = Constants.ItemNames.BackstagePasses,
                SellIn = 15,
                Quality = 20
            },
            new()
            {
                Name = Constants.ItemNames.BackstagePasses,
                SellIn = 10,
                Quality = 49
            },
            new()
            {
                Name = Constants.ItemNames.BackstagePasses,
                SellIn = 5,
                Quality = 49
            },
            new()
            {
                Name = $"{Constants.ItemPrefixes.Conjured} {Constants.ItemNames.ManaCake}", SellIn = 3, Quality = 6
            }
        };

        var app = new GildedRose(Items);

        // Parse days from args or use default
        var days = DefaultDays;
        if (args.Length > 0 && int.TryParse(args[0], out var parsedDays))
        {
            days = parsedDays;
        }

        for (var i = 0; i <= days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in Items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }

            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}