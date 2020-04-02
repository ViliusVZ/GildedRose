using GildedRose.ConsoleApp;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class UpdateQualityOnBasicItem
	{
		private GildedRoseWarehouse _warehouse = new GildedRoseWarehouse();

		public UpdateQualityOnBasicItem() => _warehouse = new GildedRoseWarehouse();

		[Fact]
		public void ReduceQuality()
		{
			var basicItem = new Item() { Name = "Basic item", Quality = 10, SellIn = 5 };
			var items = new List<Item>() { basicItem };

			var expectedQuality = items[0].Quality - 1;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, basicItem.Quality);
		}

		[Fact]
		public void ReduceSellIn()
		{
			var basicItem = new Item() { Name = "Basic item", Quality = 10, SellIn = 5 };
			var items = new List<Item>() { basicItem };

			var expectedSellIn = items[0].SellIn - 1;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedSellIn, basicItem.SellIn);
		}

		[Fact]
		public void ReduceQualityByTwoIfSellInIsZero()
		{
			var basicItem = new Item() { Name = "Basic item", Quality = 10, SellIn = 0 };
			var items = new List<Item>() { basicItem };

			var expectedQuality = 8;

			// Should do a -2 to quality because the SellIn is 0.
			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, basicItem.Quality);
		}

		[Fact]
		public void QualityOfItemIsNeverNegative()
		{
			var basicItem = new Item() { Name = "Basic item", Quality = 0, SellIn = 5 };
			var items = new List<Item>() { basicItem };

			var expectedQuality = 0;

			_warehouse.UpdateQuality(items);

			Assert.Equal(expectedQuality, basicItem.Quality);
		}
	}
}