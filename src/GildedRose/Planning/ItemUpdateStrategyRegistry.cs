using System;
using System.Collections.Generic;
using GildedRoseKata.Strategies;
using GildedRoseKata.Strategies.Implementations;

namespace GildedRoseKata.Planning;

public class ItemUpdateStrategyRegistry : IItemUpdateStrategyPlanner
{
    private readonly Dictionary<string, IItemUpdateStrategy> _namedStrategies = [];

    private readonly List<(Func<Item, bool> Predicate, IItemUpdateStrategy Strategy)> _predicateStrategies = [];

    private readonly IItemUpdateStrategy _defaultStrategy = new StandardItemStrategy();

    public ItemUpdateStrategyRegistry()
    {
        // Register exact name strategies
        _namedStrategies.Add(Constants.ItemNames.Sulfuras, new ImmutableItemStrategy());
        _namedStrategies.Add(Constants.ItemNames.AgedBrie, new QualityIncreasingStrategy());
        _namedStrategies.Add(Constants.ItemNames.BackstagePasses, new ThresholdBasedStrategy());

        // Register pattern-based strategies
        _predicateStrategies.Add((
            item => item.Name.StartsWith(Constants.ItemPrefixes.Conjured, StringComparison.OrdinalIgnoreCase),
            new DoubleDegradationStrategy()));
    }

    public IItemUpdateStrategy GetStrategyFor(Item item)
    {
        // Check for exact matches first.
        if (_namedStrategies.TryGetValue(item.Name, out var strategy))
        {
            return strategy;
        }

        // Check for pattern-based matches.
        foreach (var (predicate, predicateStrategy) in _predicateStrategies)
        {
            if (predicate(item))
            {
                return predicateStrategy;
            }
        }

        return _defaultStrategy;
    }
}