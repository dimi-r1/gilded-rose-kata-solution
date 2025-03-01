using GildedRoseKata;
using GildedRoseKata.Strategies.Implementations;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests.Strategies;

public class QualityIncreasingStrategyTests
{
    private readonly QualityIncreasingStrategy _strategy = new();

    [Fact]
    public void UpdateQuality_IncreasesQualityByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(11, item.Quality);
    }

    [Fact]
    public void UpdateQuality_DecreasesSellInByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(4, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_WhenExpired_IncreasesQualityByTwo()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(12, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithQualityNearMax_CapsAtFifty()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 49 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithMaxQuality_RemainsAtMax()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 5, Quality = 50 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WhenExpiredNearMax_CapsAtFifty()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 49 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(50, item.Quality);
    }
}