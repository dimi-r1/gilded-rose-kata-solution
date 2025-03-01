using GildedRoseKata;
using GildedRoseKata.Strategies.Implementations;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests.Strategies;

public class ImmutableItemStrategyTests
{
    private readonly ImmutableItemStrategy _strategy = new();

    [Fact]
    public void UpdateQuality_DoesNotChangeQuality()
    {
        // Arrange
        var item = new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void UpdateQuality_DoesNotChangeSellIn()
    {
        // Arrange
        var item = new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(0, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_WithNegativeSellIn_DoesNotChange()
    {
        // Arrange
        var item = new Item { Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AfterMultipleDays_RemainsUnchanged()
    {
        // Arrange
        var item = new Item { Name = ItemNames.Sulfuras, SellIn = 5, Quality = 80 };

        // Act - multiple updates
        for (var i = 0; i < 3; i++)
        {
            _strategy.UpdateQuality(item);
        }

        // Assert
        Assert.Equal(5, item.SellIn);
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void UpdateQuality_WithQualityOverFifty_AllowsExceedingMaximum()
    {
        // Arrange - quality already over 50
        var item = new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 };

        // Act
        _strategy.UpdateQuality(item);

        // Assert
        Assert.Equal(80, item.Quality);
    }
}