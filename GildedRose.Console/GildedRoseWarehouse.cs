using System.Collections.Generic;

namespace GildedRose.ConsoleApp
{
	public class GildedRoseWarehouse
	{
		public void UpdateQuality(IList<Item> items)
		{
			for (var i = 0; i < items.Count; i++)
			{
				if (items[i].Name != ItemNameDictionary.AgedBrieName && items[i].Name != ItemNameDictionary.BackstagePassName)
				{
					if (items[i].Quality > 0)
					{
						if (items[i].Name != ItemNameDictionary.SulfurasName)
						{
							items[i].Quality = items[i].Quality - 1;

							if (items[i].Name.StartsWith(ItemNameDictionary.ConjuredItemPrefix) && items[i].Quality > 0) items[i].Quality -= 1;
						}
					}
				}
				else
				{
					if (items[i].Quality < 50)
					{
						items[i].Quality = items[i].Quality + 1;

						if (items[i].Name == ItemNameDictionary.BackstagePassName)
						{
							if (items[i].SellIn < 11)
							{
								if (items[i].Quality < 50)
								{
									items[i].Quality = items[i].Quality + 1;
								}
							}

							if (items[i].SellIn < 6)
							{
								if (items[i].Quality < 50)
								{
									items[i].Quality = items[i].Quality + 1;
								}
							}
						}
					}
				}

				if (items[i].Name != ItemNameDictionary.SulfurasName)
				{
					items[i].SellIn = items[i].SellIn - 1;
				}

				if (items[i].SellIn < 0)
				{
					if (items[i].Name != ItemNameDictionary.AgedBrieName)
					{
						if (items[i].Name != ItemNameDictionary.BackstagePassName)
						{
							if (items[i].Quality > 0)
							{
								if (items[i].Name != ItemNameDictionary.SulfurasName)
								{
									items[i].Quality = items[i].Quality - 1;

									if (items[i].Name.StartsWith(ItemNameDictionary.ConjuredItemPrefix) && items[i].Quality > 0) items[i].Quality -= 1;
								}
							}
						}
						else
						{
							items[i].Quality = items[i].Quality - items[i].Quality;
						}
					}
					else
					{
						if (items[i].Quality < 50)
						{
							items[i].Quality = items[i].Quality + 1;
						}
					}
				}
			}
		}
	}
}