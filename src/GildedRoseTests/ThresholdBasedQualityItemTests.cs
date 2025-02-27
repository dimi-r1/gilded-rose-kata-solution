using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class ThresholdBasedQualityItemTests
{
    [Fact]
    public void ThresholdBasedItem_IncreasesByOneWhenMoreThan10Days()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 11, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(21, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_IncreasesByTwoWhen10DaysOrLess()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 10, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(22, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_IncreasesByTwoWhenBetween6And10Days()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 6, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(22, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_IncreasesByThreeWhen5DaysOrLess()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 5, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(23, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_IncreasesByThreeWhenBetween1And5Days()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 1, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(23, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_DropsToZeroQualityAfterConcert()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 0, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_RemainsAtZeroQualityWhenExpired()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = -1, Quality = 0 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_DecreasesSellInByOne()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 15, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(14, items[0].SellIn);
    }

    [Fact]
    public void ThresholdBasedItem_QualityDoesNotExceedFifty_WhenMoreThan10Days()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 15, Quality = 50 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_QualityDoesNotExceedFifty_When10DaysOrLess()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 10, Quality = 49 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void ThresholdBasedItem_QualityDoesNotExceedFifty_When5DaysOrLess()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 5, Quality = 48 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void MultipleThresholdBasedItems_AllBehaveProperly()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.BackstagePass, SellIn = 15, Quality = 20 },
            new() { Name = ItemNames.BackstagePass, SellIn = 10, Quality = 20 },
            new() { Name = ItemNames.BackstagePass, SellIn = 5, Quality = 20 },
            new() { Name = ItemNames.BackstagePass, SellIn = 0, Quality = 20 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(14, items[0].SellIn);
        Assert.Equal(21, items[0].Quality);
        Assert.Equal(9, items[1].SellIn);
        Assert.Equal(22, items[1].Quality);
        Assert.Equal(4, items[2].SellIn);
        Assert.Equal(23, items[2].Quality);
        Assert.Equal(-1, items[3].SellIn);
        Assert.Equal(0, items[3].Quality);
    }
}