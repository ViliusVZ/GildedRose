using GildedRose.ConsoleApp;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class UpdateQualityGeneral
	{
		private GildedRoseWarehouse _warehouse = new GildedRoseWarehouse();

		public UpdateQualityGeneral() => _warehouse = new GildedRoseWarehouse();

		[Fact]
		public void RunWithEmptyCollection() => _warehouse.UpdateQuality(new List<Item>());
	}
}