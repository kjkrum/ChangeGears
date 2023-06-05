using System.Collections.Immutable;

namespace ChangeGears
{
	public class GearSet
	{
		private ImmutableList<int> Gears { get; }

		public GearSet(params int[] gears)
		{
			Gears = ImmutableList.CreateRange(gears);
		}

		public IEnumerable<GearTrain> Permutations(int gears)
		{
			if (gears > Gears.Count) throw new ArgumentException("The number of gears cannot exceed the number of gears in the set.");
			IEnumerable<IImmutableList<int>> lists = new List<IImmutableList<int>>() { ImmutableList.Create<int>() };
			while(lists.First().Count < gears)
			{
				lists = lists.SelectMany(o => Permute(o));
			}
			return lists.Select(o => new GearTrain(o));
		}

		private IEnumerable<IImmutableList<int>> Permute(IImmutableList<int> selected)
		{
			var lists = new List<IImmutableList<int>>();
			var available = Gears.RemoveRange(selected);
			foreach(int gear in available)
			{
				lists.Add(selected.Add(gear));
			}
			return lists;
		}
	}
}
