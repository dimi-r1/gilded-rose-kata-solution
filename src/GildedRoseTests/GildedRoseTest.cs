using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Foo()
        {
            // Arrange
            var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            Assert.Equal("foo", items[0].Name);
        }
    }
}