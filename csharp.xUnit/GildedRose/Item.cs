using System;

namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }


    public void UpdateQuality()
    {
     
        var roseIsSulfuras = Name.Equals(Constants.Sulfuras);
        
        QualityUpdateManager(roseIsSulfuras);

        if (!roseIsSulfuras)
        {
            SellIn --;
        }

        HandleExpiredRoses();
    }

    private void QualityUpdateManager(bool roseIsSulfuras)
    {
        switch(Name)
        {
            case Constants.AgedBarie:
                UpdateAgeBarie();
                break;
            case Constants.Backstage:
                UpdateBackstage();
                break;
            case Constants.Sulfuras:
                UpdateSulfuras();
                break;
            default:
                UpdateNormalRoses(roseIsSulfuras);
                break;
        }
    }

    private void HandleExpiredRoses()
    {   
        if (SellIn >= 0) return;
        switch (Name)
        {
            case Constants.AgedBarie:
                UpdateAgeBarie();
                break;
            
            case Constants.Backstage:
                Quality = 0;
                break;
            
            default:
                if (Quality > 0 && Name != Constants.Sulfuras)
                {
                    Quality--;
                }
                break;
        }
    }

    private void UpdateAgeBarie()
    {
        if (Quality < 50)
        {
            Quality++;
        }
    }

    private void UpdateBackstage()
    {
        if (Quality < 50)
        {
            Quality++;
            
            if (SellIn <=10)
            {
                Quality = Math.Min(Quality + 1, 50);
            }
            
            if (SellIn <= 5)
            {
                Quality = Math.Min(Quality + 1, 50);
            }
        }
    }

    private void UpdateSulfuras()
    {
        
    }

    private void UpdateNormalRoses(bool isSulfuras)
    {
        if (Quality > 0 && !isSulfuras)
        {
            Quality--;
        }
    }
}