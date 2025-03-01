using GildedRoseKata;
using GildedRoseKata.Strategies.Implementations;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests.Strategies;

public class DoubleDegradationStrategyTests
{
    private readonly DoubleDegradationStrategy _strategy = new();

    [Fact]
    public void UpdateQuality_DecreasesQualityByTwo()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(8, item.Quality);
    }

    [Fact]
    public void UpdateQuality_DecreasesSellInByOne()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(4, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_WhenExpired_DecreasesQualityByFour()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 0, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(6, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithLowQuality_StopsAtZero()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 5, Quality = 1 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithLowQualityAndExpired_StopsAtZero()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 0, Quality = 3 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithZeroQuality_RemainsAtZero()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 5, Quality = 0 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithDifferentConjuredItem_DecreasesQualityTwiceAsFast()
    {
        // Arrange - testing different conjured item name
        var item = new Item { Name = ItemNames.AlternativeConjuredItem, SellIn = 5, Quality = 10 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(8, item.Quality);
    }
}