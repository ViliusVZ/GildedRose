﻿using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class GildedRoseTest
	{
		[Fact]
		public void foo()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
			Console.GildedRose app = new Console.GildedRose(Items);
			app.UpdateQuality();
			Assert.Equal("fixme", Items[0].Name);
		}
	}
}