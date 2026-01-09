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
    public void Sulfuras_Should_Do_Nothing()
    {
        //arrange
        IList<Item> Items = new List<Item> { new Item { Name = Constants.Sulfuras, SellIn = 0, Quality = 0 } };
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert

        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void Aged_Barie_Should_Increase_Quality_By_1_Before_SellInDate()
    {
        //arrange
        IList<Item> Items = new List<Item> { new Item { Name = Constants.AgedBarie, SellIn = 1, Quality = 0 } };
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Assert.Equal(1, Items[0].Quality);
    }
    [Fact]
    public void AgedBrie_Should_Increase_Quality_By_2_After_SellDate()
    {
        //arrange
        var items = new List<Item> { new Item { Name = Constants.AgedBarie, SellIn = 0, Quality = 10 } };
        //act
        var app = new GildedRose(items);
        app.UpdateQuality();
        //assert
        Assert.Equal(12, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_Quality_Should_Not_Exceed_50()
    {
        //arrange
        var items = new List<Item> { new Item { Name = Constants.AgedBarie, SellIn = 5, Quality = 50 } };
        //act
        var app = new GildedRose(items);
        app.UpdateQuality();
        //assert
        Assert.Equal(50, items[0].Quality);
    }
    
    [Fact]
    public void Backstage_Should_Increase_Quality_By_1_When_More_Than_10_Days()
    {
        //arrange
        IList<Item> Items = new List<Item> { new Item { Name = Constants.Backstage, SellIn = 30, Quality = 0 } };
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Assert.Equal(1, Items[0].Quality);
    }
    
    [Fact]
    public void Backstage_Should_Increase_Quality_By_2_When_10_Days_Or_Less()
    {
        //arrange
        IList<Item> Items = new List<Item> { new Item { Name = Constants.Backstage, SellIn = 7, Quality = 0 } };
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Assert.Equal(2, Items[0].Quality);
    }

    [Fact]
    public void Backstage_should_Increase_Qualtiy_By_3()
    {
        //arrange
        IList<Item> Items = new List<Item> { new Item { Name = Constants.Backstage, SellIn = 4, Quality = 0 } };
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Assert.Equal(3, Items[0].Quality);
    }
    
    [Fact]
    public void Backstage_Should_Increase_Quality_By_3_When_5_Days_Or_Less()
    {
        //arrange
        var items = new List<Item> { new Item { Name = Constants.Backstage, SellIn = 5, Quality = 10 } };
        //act
        var app = new GildedRose(items);
        app.UpdateQuality();
        //assert
        Assert.Equal(13, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }
    
    [Fact]
    public void Backstage_Quality_Should_Drop_To_0_After_SellDate()
    {
        //arrange
        var items = new List<Item> { new Item { Name = Constants.Backstage, SellIn = 0, Quality = 10 } };
        //act
        var app = new GildedRose(items);
        app.UpdateQuality();
        //assert
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }
    
    [Fact]
    public void ConjuredItem_Quality_Should_Not_Go_Below_0()
    {
        //arrange
        var items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 2 } };
        //act
        var app = new GildedRose(items);
        app.UpdateQuality();
        //assert
        Assert.Equal(0, items[0].Quality);
    }

}