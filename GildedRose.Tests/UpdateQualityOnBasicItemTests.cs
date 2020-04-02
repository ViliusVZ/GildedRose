using GildedRose.ConsoleApp;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class UpdateQualityOnBasicItemTests
	{
		[Fact]
		public void RunWithEmptyCollection()
		{
			var warehouse = new GildedRoseWarehouse();
			warehouse.UpdateQuality(new List<Item>());
		}

		[Fact]
		public void ReduceQuality()
		{
			var warehouse = new GildedRoseWarehouse();
			var basicItem = new Item() { Name = "Basic item", Quality = 10, SellIn = 5 };
			var items = new List<Item>() { basicItem };

			var expectedQuality = items[0].Quality - 1;

			warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, basicItem.Quality);
		}

		[Fact]
		public void ReduceSellIn()
		{
			var warehouse = new GildedRoseWarehouse();
			var basicItem = new Item() { Name = "Basic item", Quality = 10, SellIn = 5 };
			var items = new List<Item>() { basicItem };

			var expectedSellIn = items[0].SellIn - 1;

			warehouse.UpdateQuality(items);

			Assert.Equal(expectedSellIn, basicItem.SellIn);
		}

		[Fact]
		public void ReduceQualityByTwoIfSellInIsZero()
		{
			var warehouse = new GildedRoseWarehouse();
			var basicItem = new Item() { Name = "Basic item", Quality = 10, SellIn = 0 };
			var items = new List<Item>() { basicItem };

			var expectedQuality = 8;

			// Should do a -2 to quality because the SellIn is 0.
			warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, basicItem.Quality);
		}
	}
}