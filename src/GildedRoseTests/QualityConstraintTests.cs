using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class QualityConstraintTests
{
    [Fact]
    public void QualityNeverExceedsFifty()
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
    public void QualityNeverBelowZero()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.StandardItem, SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void QualityNeverBelowZero_WhenExpired()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.StandardItem, SellIn = 0, Quality = 1 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityDoesNotExceedFifty_WhenExpired()
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
    public void BackstagePasses_QualityDoesNotExceedFifty_WhenTenDaysLeft()
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
    public void BackstagePasses_QualityDoesNotExceedFifty_WhenFiveDaysLeft()
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
    public void Sulfuras_QualityCanExceedFifty()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(80, items[0].Quality);
        Assert.True(items[0].Quality > 50);
    }

    [Fact]
    public void MultipleItems_AllRespectQualityConstraints()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.StandardItem, SellIn = 0, Quality = 1 },
            new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 49 },
            new() { Name = ItemNames.BackstagePass, SellIn = 5, Quality = 48 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(50, items[1].Quality);
        Assert.Equal(50, items[2].Quality);
    }
}