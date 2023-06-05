namespace ChangeGears
{
	public static class Program
	{
		public const int SpindleGear = 40;
		public const int LeadPitch = 2;

		public static void Main()
		{
			var gearSet = new GearSet(20, 24, 30, 40, 50, 50, 60, 63, 66, 72, 80, 80);

			var gearTrains = gearSet
				.Permutations(1)
				.Concat(gearSet.Permutations(3))
				// TODO filter 5-gear solutions that are too short?
				.Concat(gearSet.Permutations(5))
				.Where(o => o.IsBuildable())
				.Distinct();

			Metric(gearTrains);
			Standard(gearTrains);
		}

		private static void Metric(IEnumerable<GearTrain> gearTrains)
		{
			var metricThreads = gearTrains
				.Select(o => new MetricThread(SpindleGear, o, LeadPitch))
				.Where(o => o.IsCommonPitch() || o.Pitch == 0.1m)
				.GroupBy(o => o.Pitch)
				.Select(o => o
					.OrderByDescending(o => o.GearTrain.Gears.Min())
					.ThenBy(o => o.GearTrain.Gears.Count)
				.First())
				.OrderBy(o => o.Pitch);
			Console.Out.WriteLine("Gears|Pitch");
			foreach (var thread in metricThreads)
			{
				Console.Out.WriteLine($"{string.Join(",", thread.GearTrain.Gears)}|{thread.Pitch}");
			}
			Console.Out.WriteLine();
		}

		private static void Standard(IEnumerable<GearTrain> gearTrains)
		{
			var standardThreads = gearTrains
				.Select(o => new StandardThread(SpindleGear, o, LeadPitch))
				.Where(o => o.IsCommonTPI())
				.GroupBy(o => o.TPI)
				.Select(o => o
					.OrderBy(o => o.Error)
					.ThenByDescending(o => o.GearTrain.Gears.Min())
					.ThenBy(o => o.GearTrain.Gears.Count)
				.First())
				.OrderBy(o => o.TPI);
			Console.Out.WriteLine("Gears|TPI|Error");
			foreach (var thread in standardThreads)
			{
				Console.Out.WriteLine($"{string.Join(",", thread.GearTrain.Gears)}|{thread.TPI}|{thread.Error:P2}");
			}
			Console.Out.WriteLine();
		}
	}
}
