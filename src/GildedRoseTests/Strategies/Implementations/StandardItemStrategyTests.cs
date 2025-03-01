using GildedRoseKata;
using GildedRoseKata.Strategies.Implementations;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests.Strategies;

public class StandardItemStrategyTests
{
    private readonly StandardItemStrategy _strategy = new();

    [Fact]
    public void UpdateQuality_DecreasesQualityByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(9, item.Quality);
    }

    [Fact]
    public void UpdateQuality_DecreasesSellInByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(4, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_WhenExpired_DecreasesQualityByTwo()
    {
        // Arrange
        var item = new Item { Name = ItemNames.StandardItem, SellIn = 0, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(8, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithZeroQuality_DoesNotDecreasesFurther()
    {
        // Arrange
        var item = new Item { Name = ItemNames.StandardItem, SellIn = 5, Quality = 0 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WhenExpiredWithQualityOne_DecreasesToZero()
    {
        // Arrange
        var item = new Item { Name = ItemNames.StandardItem, SellIn = 0, Quality = 1 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }
}