using Fractions;

namespace ChangeGears
{
	// https://www.engineeringtoolbox.com/metric-threads-d_777.html

	public class MetricThread
	{
		public GearTrain GearTrain { get; }
		public Fraction ExactPitch { get; }
		public decimal Pitch { get; }

		public MetricThread(int spindleGear, GearTrain gearTrain, int leadPitch)
		{
			GearTrain = gearTrain;
			ExactPitch = gearTrain.ThreadPitch(spindleGear, leadPitch);
			Pitch = Math.Round(ExactPitch.ToDecimal(), 2);
		}

		public static readonly Fraction M4 = new(7, 10);
		public static readonly Fraction M5 = new(8, 10);

		public bool IsCommonPitch()
		{
			return
				ExactPitch.Denominator == 1 ||
				ExactPitch < 6 && ExactPitch.Denominator == 2 ||
				ExactPitch < 2 && ExactPitch.Denominator == 4 ||
				ExactPitch == M5 ||
				ExactPitch == M4;
				// try this if nothing hits 0.7 exactly
				//Math.Abs(ExactPitch.ToDecimal() - M4.ToDecimal()) <= 0.01m;
		}
	}
}
