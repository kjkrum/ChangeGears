namespace ChangeGears.Test
{
	[TestClass]
	public class GearTrainBuildabilityTests
	{
		[TestMethod]
		public void Yeah_50_40_80_63_72()
		{
			var gt = new GearTrain(50, 40, 80, 63, 72);
			Assert.IsTrue(gt.IsBuildable());
		}

		[TestMethod]
		public void Yeah_72_30_80_24_80()
		{
			var gt = new GearTrain(72, 30, 80, 24, 80);
			Assert.IsTrue(gt.IsBuildable());
		}

		/* Negative tests should identify the point of interference. */

		[TestMethod]
		public void Nah_80_20_80()
		{
			var gt = new GearTrain(80, 20, 80);
			// no step or spindle interaction on a 3-gear train
			Assert.IsTrue(gt.SpindleClear());
			Assert.IsTrue(gt.StepClear());
			Assert.IsFalse(gt.SpacerClear());
		}

		[TestMethod]
		public void Nah_80_60_80_63_50()
		{
			var gt = new GearTrain(80, 60, 80, 63, 50);
			Assert.IsTrue(gt.SpindleClear());
			Assert.IsFalse(gt.StepClear());
			Assert.IsTrue(gt.SpacerClear());
		}
	}
}
