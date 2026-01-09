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
                            Quality = Quality + 1;
                        }
                    }
                }
            }
        }

        if (Name != Constants.Sulfuras)
        {
            SellIn = SellIn - 1;
        }

        if (SellIn < 0)
        {
            if (Name != Constants.AgedBarie)
            {
                if (Name != Constants.Backstage)
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
                    Quality = Quality - Quality;
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