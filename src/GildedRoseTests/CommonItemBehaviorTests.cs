using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;

namespace GildedRoseTests;

public class CommonItemBehaviorTests
{
    [Fact]
    public void UpdateQuality_DoesNotChangeItemName()
    {
        // Arrange
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal("foo", items[0].Name);
    }
    
    [Fact]
    public void UpdateQuality_ProcessesMultipleItems()
    {
        // Arrange
        var items = new List<Item> 
        { 
            new() { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 },
            new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 10 },
            new() { Name = ItemNames.Sulfuras, SellIn = 5, Quality = 80 }
        };
        var app = new GildedRose(items);
        
        // Act
        app.UpdateQuality();
        
        // Assert
        Assert.Equal(4, items[0].SellIn); // Standard item SellIn decreases
        Assert.Equal(9, items[0].Quality); // Standard item Quality decreases
        Assert.Equal(4, items[1].SellIn); // Aged Brie SellIn decreases
        Assert.Equal(11, items[1].Quality); // Aged Brie Quality increases
        Assert.Equal(5, items[2].SellIn); // Sulfuras SellIn unchanged
        Assert.Equal(80, items[2].Quality); // Sulfuras Quality unchanged
    }
}