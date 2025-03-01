using GildedRoseKata;
using GildedRoseKata.Planning;
using GildedRoseKata.Strategies.Implementations;
using GildedRoseTests.Constants;
using Xunit;

namespace GildedRoseTests.Planning;

public class ItemUpdateStrategyRegistryTests
{
    private readonly ItemUpdateStrategyRegistry _registry = new();
    
    [Fact]
    public void GetStrategyFor_StandardItem_ReturnsStandardStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<StandardItemStrategy>(strategy);
    }
    
    [Fact]
    public void GetStrategyFor_AgedBrie_ReturnsQualityIncreasingStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<QualityIncreasingStrategy>(strategy);
    }
    
    [Fact]
    public void GetStrategyFor_BackstagePasses_ReturnsThresholdBasedStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.BackstagePass, SellIn = 15, Quality = 20 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<ThresholdBasedStrategy>(strategy);
    }
    
    [Fact]
    public void GetStrategyFor_Sulfuras_ReturnsImmutableItemStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<ImmutableItemStrategy>(strategy);
    }
    
    [Fact]
    public void GetStrategyFor_ConjuredItem_ReturnsDoubleDegradationStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<DoubleDegradationStrategy>(strategy);
    }
    
    [Fact]
    public void GetStrategyFor_ConjuredItemWithDifferentCase_ReturnsDoubleDegradationStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.AlternativeConjuredItem.ToLower(), SellIn = 3, Quality = 6 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<DoubleDegradationStrategy>(strategy);
    }
    
    [Fact]
    public void GetStrategyFor_UnknownItem_ReturnsStandardStrategy()
    {
        // Arrange
        var item = new Item { Name = ItemNames.StandardItem, SellIn = 5, Quality = 10 };
        
        // Act
        var strategy = _registry.GetStrategyFor(item);
        
        // Assert
        Assert.IsType<StandardItemStrategy>(strategy);
    }
}