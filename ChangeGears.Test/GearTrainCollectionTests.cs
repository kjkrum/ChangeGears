namespace ChangeGears.Test
{
	[TestClass]
	public class GearTrainCollectionTests
	{

		[TestMethod]
		public void TestEquality()
		{
			var gearTrain0 = new GearTrain(1, 2, 3);
			var gearTrain1 = new GearTrain(1, 2, 3);
			var gearTrain2 = new GearTrain(2, 1, 3);
			Assert.AreEqual(gearTrain0, gearTrain1);
			Assert.AreNotEqual(gearTrain0, gearTrain2);
		}

		[TestMethod]
		public void TestDistinct()
		{
			IEnumerable<GearTrain> list = new List<GearTrain>
			{
				new GearTrain(10, 20, 30),
				new GearTrain(10, 20, 30)
			};
			list = list.Distinct();
			Assert.AreEqual(1, list.Count());
		}
	}
}
