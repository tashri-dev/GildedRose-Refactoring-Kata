using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Fact]
    public void Sulfuras_Should_Do_Nothing(){

        //arrange
        IList<Item> Items = new List<Item> { new Item { Name = Constants.Sulfuras, SellIn = 0, Quality = 0 } };
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Assert.Equal(0, Items[0].Quality);
    }
}