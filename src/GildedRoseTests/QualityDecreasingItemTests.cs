using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests;

public class QualityDecreasingItemTests
{
    [Fact]
    public void StandardItem_DecreasesSellInByOne()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, items[0].SellIn);
    }

    [Fact]
    public void StandardItem_DecreasesQualityByOne()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(9, items[0].Quality);
    }

    [Fact]
    public void StandardItem_WithExpiredSellIn_DecreasesQualityByTwo()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.StandardItem, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void StandardItem_WithQualityZero_DoesNotDecreaseQualityFurther()
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
    public void StandardItem_WithExpiredSellInAndQualityOne_DecreasesToQualityZero()
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
    public void MultipleStandardItems_AllDecreaseProperly()
    {
        // Arrange
        var items = new List<Item>
        {
            new() { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 },
            new() { Name = ItemNames.StandardItem, SellIn = 0, Quality = 10 },
            new() { Name = ItemNames.StandardItem, SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(9, items[0].Quality);
        Assert.Equal(-1, items[1].SellIn);
        Assert.Equal(8, items[1].Quality);
        Assert.Equal(4, items[2].SellIn);
        Assert.Equal(0, items[2].Quality);
    }

    [Fact]
    public void DexterityVest_BehavesLikeStandardItem()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.DexterityVest, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(9, items[0].Quality);
    }

    [Fact]
    public void Elixir_BehavesLikeStandardItem()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.Elixir, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(9, items[0].Quality);
    }

    [Fact]
    public void DexterityVest_WithExpiredSellIn_DecreasesQualityByTwo()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.DexterityVest, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void Elixir_WithExpiredSellIn_DecreasesQualityByTwo()
    {
        // Arrange
        var items = new List<Item> { new() { Name = ItemNames.Elixir, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);
    }
}