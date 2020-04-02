using GildedRose.ConsoleApp;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class UpdateQualityOnSpecialItem
	{
		private const string AgedBrieName = "Aged Brie";
		private const string SulfurasName = "Sulfuras, Hand of Ragnaros";
		private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
		private const string ConjuredItemName = "Conjured Pie";

		private GildedRoseWarehouse _warehouse = new GildedRoseWarehouse();

		public UpdateQualityOnSpecialItem() => _warehouse = new GildedRoseWarehouse();

		[Fact]
		// This also covers for "Aged Brie actually increases in Quality the older it gets".
		public void QualityOfItemIsNeverMoreThanFifty()
		{
			var specialItem = new Item() { Name = AgedBrieName, Quality = 50, SellIn = 5 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 50;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		#region Legendary items

		[Fact]
		public void LegendaryItemsNeverReduceInQuality()
		{
			var specialItem = new Item() { Name = SulfurasName, SellIn = 0, Quality = 80 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 80;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		[Fact]
		public void LegendaryItemsNeverReduceInSellIn()
		{
			var specialItem = new Item() { Name = SulfurasName, SellIn = 0, Quality = 80 };
			var items = new List<Item>() { specialItem };

			var expectedSellIn = 0;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedSellIn, specialItem.SellIn);
		}

		#endregion Legendary items

		#region Backstage passes

		[Fact]
		public void BackstagePassIncreasesInQualityByTwo_WhenSellInIsTen()
		{
			var specialItem = new Item() { Name = BackstagePassName, SellIn = 10, Quality = 30 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 32;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		[Fact]
		public void BackstagePassIncreasesInQualityByThree_WhenSellInIsFive()
		{
			var specialItem = new Item() { Name = BackstagePassName, SellIn = 5, Quality = 30 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 33;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		[Fact]
		public void BackstagePassQualityDropsToZero_WhenSellInIsNegativeOne()
		{
			var specialItem = new Item() { Name = BackstagePassName, SellIn = 0, Quality = 30 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 0;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		#endregion Backstage passes

		#region Conjured Items

		[Fact]
		public void ConjuredItemsDegradeInQualityTwiceAsFast_WhenSellInIsAboveZero()
		{
			var specialItem = new Item() { Name = ConjuredItemName, SellIn = 1, Quality = 20 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 18;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		[Fact]
		public void ConjuredItemsDegradeInQualityTwiceAsFast_WhenSellInIsBelowZero()
		{
			var specialItem = new Item() { Name = ConjuredItemName, SellIn = -1, Quality = 20 };
			var items = new List<Item>() { specialItem };

			var expectedQuality = 16;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, specialItem.Quality);
		}

		#endregion Conjured Items
	}
}