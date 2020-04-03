using System.Collections.Generic;

namespace GildedRose.ConsoleApp
{
	public class GildedRoseWarehouse
	{
		public void UpdateQuality(IList<Item> items)
		{
			foreach (var item in items)
			{
				if (item.Name != ItemNameDictionary.SulfurasName)
					item.SellIn -= 1;

				switch (item.Name)
				{
					case ItemNameDictionary.SulfurasName:
						break;

					case ItemNameDictionary.AgedBrieName:
						IncreaseItemQuality(item);
						if (item.SellIn < 0)
							IncreaseItemQuality(item);
						break;

					case ItemNameDictionary.BackstagePassName:
						IncreaseItemQuality(item);
						if (item.SellIn < 10) IncreaseItemQuality(item);
						if (item.SellIn < 5) IncreaseItemQuality(item);
						if (item.SellIn < 0) item.Quality = 0;
						break;

					default:
						DecreaseItemQuality(item);

						if (item.Name.StartsWith(ItemNameDictionary.ConjuredItemPrefix) && item.Quality > 0)
						{
							DecreaseItemQuality(item);
							if (item.SellIn < 0) DecreaseItemQuality(item);
						}

						if (item.SellIn < 0)
							DecreaseItemQuality(item);
						break;
				}
			}
		}

		private void DecreaseItemQuality(Item item)
		{
			if (item.Quality > 0)
				item.Quality -= 1;
		}

		private void IncreaseItemQuality(Item item)
		{
			if (item.Quality < 50)
				item.Quality += 1;
		}
	}
}