using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class ImmutableItemTests
{
    [Fact]
    public void ImmutableItem_DoesNotChangeQualityOrSellIn()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void ImmutableItem_WithNegativeSellIn_DoesNotChange()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void ImmutableItem_AfterMultipleDays_DoesNotChange()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.Sulfuras, SellIn = 10, Quality = 80 }
        };
        var app = new GildedRose(items);

        // Act
        for (var i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }

        // Assert
        Assert.Equal(10, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void ImmutableItem_QualityCanExceedFifty()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(80, items[0].Quality);
        Assert.True(items[0].Quality > 50);
    }

    [Fact]
    public void MultipleImmutableItems_AllRemainUnchanged()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.Sulfuras, SellIn = 5, Quality = 80 },
            new() { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 },
            new() { Name = ItemNames.Sulfuras, SellIn = -3, Quality = 80 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(5, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(0, items[1].SellIn);
        Assert.Equal(80, items[1].Quality);
        Assert.Equal(-3, items[2].SellIn);
        Assert.Equal(80, items[2].Quality);
    }
}