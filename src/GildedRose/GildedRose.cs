using System.Collections.Generic;
using GildedRoseKata.Planning;

namespace GildedRoseKata;

public class GildedRose
{
    // We can't make this private or rename this to follow conventions due to requirements
    IList<Item> Items;
    
    private readonly ItemUpdateStrategyRegistry _strategyPlanner;
    
    public GildedRose(IList<Item> items)
    {
        Items = items;
        _strategyPlanner = new ItemUpdateStrategyRegistry();
    }
    
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var strategy = _strategyPlanner.GetStrategyFor(item);
            strategy.UpdateQuality(item);
        }
    }
}