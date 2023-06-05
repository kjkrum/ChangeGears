namespace ChangeGears.Test
{
	[TestClass]
	public class GearSetTests
	{
		[TestMethod]
		public void TestPermutations()
		{
			var gearSet = new GearSet(1, 2, 3, 4, 5);
			var permutations = gearSet.Permutations(3);
			Assert.AreEqual(5 * 4 * 3, permutations.Count());
		}
	}
}
