namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }


    public void UpdateQuality()
    {
        var roseIsAgedBarie = Name.Equals(Constants.AgedBarie);
        var roseIsBackstage = Name.Equals(Constants.Backstage);
        var roseIsSulfuras = Name.Equals(Constants.Sulfuras);
        
        if (!roseIsAgedBarie && !roseIsBackstage)
        {
            if (Quality > 0)
            {
                if (!roseIsSulfuras)
                {
                    Quality --;
                }
            }
        }
        else
        {
            if (Quality < 50)
            {
                Quality++;

                if (Name == Constants.Backstage)
                {
                    if (SellIn < 11)
                    {
                        if (Quality < 50)
                        {
                            Quality ++;
                        }
                    }

                    if (SellIn < 6)
                    {
                        if (Quality < 50)
                        {
                            Quality ++;
                        }
                    }
                }
            }
        }

        if (!roseIsSulfuras)
        {
            SellIn --;
        }

        HandleExpiredRoses(roseIsAgedBarie, roseIsBackstage);
    }

    private void HandleExpiredRoses(bool roseIsAgedBarie, bool roseIsBackstage)
    {
        if (SellIn < 0)
        {
            if (!roseIsAgedBarie)
            {
                if (!roseIsBackstage)
                {
                    if (Quality > 0)
                    {
                        if (Name != Constants.Sulfuras)
                        {
                            Quality --;
                        }
                    }
                }
                else
                {
                    Quality = 0;
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality ++;
                }
            }
        }
    }

    private void UpdateAgeBarie()
    {
        if (Quality < 50)
        {
            Quality++;
        }
    }
}