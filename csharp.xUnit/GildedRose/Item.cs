namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }


    public void UpdateQuality()
    {
        if (this.Name != Constants.AgedBarie && this.Name != Constants.Backstage)
        {
            if (this.Quality > 0)
            {
                if (this.Name != "Sulfuras, Hand of Ragnaros")
                {
                    this.Quality = this.Quality - 1;
                }
            }
        }
        else
        {
            if (this.Quality < 50)
            {
                this.Quality = this.Quality + 1;

                if (this.Name == Constants.Backstage)
                {
                    if (this.SellIn < 11)
                    {
                        if (this.Quality < 50)
                        {
                            this.Quality = this.Quality + 1;
                        }
                    }

                    if (this.SellIn < 6)
                    {
                        if (this.Quality < 50)
                        {
                            this.Quality = this.Quality + 1;
                        }
                    }
                }
            }
        }

        if (this.Name != "Sulfuras, Hand of Ragnaros")
        {
            this.SellIn = this.SellIn - 1;
        }

        if (this.SellIn < 0)
        {
            if (this.Name != Constants.AgedBarie)
            {
                if (this.Name != Constants.Backstage)
                {
                    if (this.Quality > 0)
                    {
                        if (this.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            this.Quality = this.Quality - 1;
                        }
                    }
                }
                else
                {
                    this.Quality = this.Quality - this.Quality;
                }
            }
            else
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;
                }
            }
        }
    }
}