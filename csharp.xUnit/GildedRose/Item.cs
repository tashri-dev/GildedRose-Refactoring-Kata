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
        
        if (!roseIsAgedBarie && !roseIsBackstage)
        {
            if (Quality > 0)
            {
                if (Name != Constants.Sulfuras)
                {
                    Quality = Quality - 1;
                }
            }
        }
        else
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;

                if (Name == Constants.Backstage)
                {
                    if (SellIn < 11)
                    {
                        if (Quality < 50)
                        {
                            Quality = Quality + 1;
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

        if (Name != Constants.Sulfuras)
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
                            Quality = Quality - 1;
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
                    Quality = Quality + 1;
                }
            }
        }
    }
}