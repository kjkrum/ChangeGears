using Fractions;
using System.Collections.Immutable;

namespace ChangeGears
{
	/// <summary>
	/// The gears on the banjo and lead screw.
	/// </summary>
	public class GearTrain : IEquatable<GearTrain?>
	{
		public IImmutableList<int> Gears { get; }

		public GearTrain(params int[] gears) : this(ImmutableList.CreateRange(gears)) { }

		public GearTrain(IImmutableList<int> gears)
		{
			if (gears.Count < 1 || gears.Count > 5) throw new ArgumentException("The number of gears must be between 1 and 5 inclusive.");
			if (gears.Count % 2 == 0) throw new ArgumentException("The number of gears must be odd.");
			Gears = gears;
		}

		public Fraction ThreadPitch(int spindleGear, int leadPitch)
		{
			var pitch = new Fraction(spindleGear * leadPitch);
			for(int i = 0; i < Gears.Count; ++i)
			{
				if(i % 2 == 0)
				{
					pitch /= Gears[i];
				}
				else
				{
					pitch *= Gears[i];
				}
			}
			return pitch;
		}

		/// <summary>
		/// The distance from the center of the lead screw to the center of
		/// the top shaft on the banjo.
		/// </summary>
		/// <returns></returns>
		public decimal Length() => Gears.Skip(1).Sum() / 2m;

		public bool IsBuildable()
		{
			return SpindleClear() && StepClear() && SpacerClear();
		}

		/// <summary>
		/// Diameter of the lead screw spacer.
		/// </summary>
		private const int SpacerDiameter = 18;
		/// <summary>
		/// Tip circle minus pitch circle.
		/// </summary>
		private const int ToothDiameter = 2;

		/// <summary>
		/// <c>Gears[1]</c> does not interfere with the spindle.
		/// </summary>
		/// <returns></returns>
		public bool SpindleClear()
		{
			if (Gears.Count < 5) return true;
			return Gears[0] > Gears[1];
		}

		/// <summary>
		/// <c>Gears[0]</c> does not interfere with <c>Gears[3]</c>.
		/// </summary>
		/// <returns></returns>
		public bool StepClear()
		{
			if (Gears.Count < 5) return true;
			return Gears[0] + ToothDiameter - Gears[1] < Gears[2] - (Gears[3] + ToothDiameter);
		}

		/// <summary>
		/// <c>Gears[^3]</c> does not interfere with the lead screw spacer.
		/// </summary>
		/// <returns></returns>
		public bool SpacerClear()
		{
			if (Gears.Count < 3) return true;
			return Gears[^3] - Gears[^2] + ToothDiameter < Gears[^1] - SpacerDiameter;
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as GearTrain);
		}

		public bool Equals(GearTrain? other)
		{
			return other is not null && Gears.SequenceEqual(other.Gears);
		}

		public override int GetHashCode()
		{
			var hash = new HashCode();
			foreach(var i in Gears)
			{
				hash.Add(i);
			}
			return hash.ToHashCode();
		}
	}
}
