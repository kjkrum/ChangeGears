using Fractions;

namespace ChangeGears
{
	// https://www.engineeringtoolbox.com/unified-screw-threads-unc-unf-d_1809.html

	public class StandardThread
	{
		public GearTrain GearTrain { get; }
		public Fraction ExactTPI { get; }
		public int TPI { get; }
		public decimal Error { get; }

		public StandardThread(int spindleGear, GearTrain gearTrain, int leadPitch)
		{
			GearTrain = gearTrain;
			ExactTPI = gearTrain.ThreadPitch(spindleGear, leadPitch) * 127 / 5;
			TPI = (int)Math.Round(ExactTPI.ToDecimal(), 0);
			Error = Math.Abs(ExactTPI.ToDecimal() - TPI) / TPI;
		}

		private static readonly IList<int> CommonTPIs = new List<int>()
		{
			// https://www.engineeringtoolbox.com/unified-screw-threads-unc-unf-d_1809.html
			48, 40, 36, 32, 28, 24, 20, 18, 16, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4
		}.AsReadOnly();

		public bool IsCommonTPI()
		{
			return CommonTPIs.Contains(TPI);
		}
	}
}
