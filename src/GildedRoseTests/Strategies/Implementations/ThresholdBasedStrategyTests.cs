using GildedRoseKata;
using GildedRoseKata.Strategies.Implementations;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests.Strategies;

public class ThresholdBasedStrategyTests
{
    private readonly ThresholdBasedStrategy _strategy = new();

    [Fact]
    public void UpdateQuality_WhenMoreThan10Days_IncreasesByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 11, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void UpdateQuality_When10DaysOrLess_IncreasesByTwo()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 10, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void UpdateQuality_Between6And10Days_IncreasesByTwo()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 6, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void UpdateQuality_When5DaysOrLess_IncreasesByThree()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 5, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void UpdateQuality_Between1And5Days_IncreasesByThree()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 1, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AfterExpiration_DropsToZero()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 0, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_DecreaseSellInByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 15, Quality = 20 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(14, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_WithQualityNearMax_RespectsMaximum()
    {
        // Arrange - test with 10 days left, should increase by 2 but cap at 50
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 10, Quality = 49 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithQualityNearMaxAndHighIncrease_RespectsMaximum()
    {
        // Arrange - test with 5 days left, should increase by 3 but cap at 50
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 5, Quality = 48 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(50, item.Quality);
    }
}