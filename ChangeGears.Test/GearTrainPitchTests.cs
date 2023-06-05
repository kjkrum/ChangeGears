using Fractions;

namespace ChangeGears.Test
{
	[TestClass]
	public class GearTrainPitchTests
	{
		[TestMethod]
		public void TestGearTrainWithNoPairs()
		{
			var gearTrain = new GearTrain(80);
			var pitch = gearTrain.ThreadPitch(40, 2);
			Assert.AreEqual(new Fraction(1, 1), pitch);
		}

		[TestMethod]
		public void TestGearTrainWithOnePair()
		{
			var gearTrain = new GearTrain(80, 40, 80);
			var pitch = gearTrain.ThreadPitch(40, 2);
			Assert.AreEqual(new Fraction(1, 2), pitch);
		}
	}
}