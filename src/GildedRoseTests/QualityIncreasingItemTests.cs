using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class QualityIncreasingItemTests
{
    [Fact]
    public void QualityIncreasingItem_IncreasesQualityByOne()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(11, items[0].Quality);
    }

    [Fact]
    public void QualityIncreasingItem_DecreasesSellInByOne()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, items[0].SellIn);
    }

    [Fact]
    public void QualityIncreasingItem_WithExpiredSellIn_IncreasesQualityByTwo()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(12, items[0].Quality);
    }

    [Fact]
    public void QualityIncreasingItem_WithQualityFortyNine_IncreasesToFifty()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 49 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void QualityIncreasingItem_WithQualityFifty_DoesNotIncreaseQualityFurther()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 50 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void QualityIncreasingItem_WithExpiredSellInAndQualityFortyNine_IncreasesToFifty()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 49 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void QualityIncreasingItem_WithExpiredSellInAndQualityFifty_DoesNotIncreaseQuality()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 50 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void QualityIncreasingItem_WithNegativeSellIn_ContinuesToIncreaseQuality()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = -5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(-6, items[0].SellIn);
        Assert.Equal(12, items[0].Quality);
    }

    [Fact]
    public void MultipleQualityIncreasingItems_AllIncreaseProperly()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 10 },
            new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 10 },
            new() { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 50 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(11, items[0].Quality);
        Assert.Equal(-1, items[1].SellIn);
        Assert.Equal(12, items[1].Quality);
        Assert.Equal(4, items[2].SellIn);
        Assert.Equal(50, items[2].Quality);
    }
}