using Xunit;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace GildedRose.Console
{
	[UseReporter(typeof(DiffReporter))]
	public class ApprovalTest
	{
		[Fact]
		public void ThirtyDays()
		{
			var fakeoutput = new StringBuilder();
			System.Console.SetOut(new StringWriter(fakeoutput));
			System.Console.SetIn(new StringReader("a\n"));

			Program.Main(new string[] { });
			var output = fakeoutput.ToString();

			Approvals.Verify(output);
		}
	}
}