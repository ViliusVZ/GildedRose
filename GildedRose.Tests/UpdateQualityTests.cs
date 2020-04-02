using GildedRose.ConsoleApp;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class UpdateQualityTests
	{
		[Fact]
		public void RunWithEmptyCollection()
		{
			var warehouse = new GildedRoseWarehouse();
			warehouse.UpdateQuality(new List<Item>());
		}
	}
}