using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseIntegrationTests
{
    [Fact]
    public void UpdateQuality_ProcessesAllItemTypesCorrectly()
    {
        var items = new List<Item>
        {
            // Standard item
            new() { Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20 },
            
            // Quality increasing item
            new() { Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0 },
            
            // Threshold-based item
            new() { Name = ItemNames.BackstagePass, SellIn = 15, Quality = 20 },
            
            // Immutable item
            new() { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 },
            
            // Double degradation item
            new() { Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6 }
        };
        
        var app = new GildedRose(items);
        
        // Act
        app.UpdateQuality();
        
        // Assert
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);
        
        Assert.Equal(1, items[1].SellIn);
        Assert.Equal(1, items[1].Quality);
        
        Assert.Equal(14, items[2].SellIn);
        Assert.Equal(21, items[2].Quality);
        
        Assert.Equal(0, items[3].SellIn);
        Assert.Equal(80, items[3].Quality);
        
        Assert.Equal(2, items[4].SellIn);
        Assert.Equal(4, items[4].Quality);
    }
    
    [Fact]
    public void UpdateQuality_HandlesSellInExpirationCorrectly()
    {
        var items = new List<Item>
        {
            // Standard item
            new() { Name = ItemNames.DexterityVest, SellIn = 0, Quality = 20 },
            
            // Quality increasing item
            new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 0 },
            
            // Threshold-based item
            new() { Name = ItemNames.BackstagePass, SellIn = 0, Quality = 20 },
            
            // Double degradation item
            new() { Name = ItemNames.ConjuredManaCake, SellIn = 0, Quality = 6 }
        };
        
        var app = new GildedRose(items);
        
        // Act
        app.UpdateQuality();
        
        // Assert
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
        
        Assert.Equal(-1, items[1].SellIn);
        Assert.Equal(2, items[1].Quality);
        
        Assert.Equal(-1, items[2].SellIn);
        Assert.Equal(0, items[2].Quality);
        
        Assert.Equal(-1, items[3].SellIn);
        Assert.Equal(2, items[3].Quality);
    }
}