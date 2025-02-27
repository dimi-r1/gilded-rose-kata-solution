using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class ConjuredItemTests
{
    [Fact]
    public void ConjuredItems_DegradeTwiceAsFast() // TODO: Fails as we need to update the UpdateQuality() method.
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.ConjuredManaCake, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void ConjuredItems_WithExpiredSellIn_DegradeTwiceAsFast() // TODO: Fails as we need to update the UpdateQuality() method.
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.ConjuredManaCake, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(6, items[0].Quality);
    }

    [Fact]
    public void ConjuredItems_QualityNeverBelowZero()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.ConjuredManaCake, SellIn = 5, Quality = 1 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void GenericConjuredItems_DegradeTwiceAsFast() // TODO: Fails as we need to update the UpdateQuality() method.
    {
        // Arrange
        var items = new List<Item> { new() { Name = "Conjured Health Potion", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void ConjuredPrefixDetection_IsCaseInsensitive() // TODO: Fails as we need to update the UpdateQuality() method.
    {
        // Arrange
        var items = new List<Item> { new() { Name = "conjured Cheese Salad", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(8, items[0].Quality);
    }
}