using System;
using System.Collections.Generic;
using System.Linq;
using LINQ.Models;

namespace LINQ
{
	class Program
  {
    static void Main(string[] args)
    {
			GroupJoin();
		}

		static void GroupJoin()
		{
			var racers = from cs in Formula1.GetChampionships()
									 from r in new List<(Int32 Year, Int32 Position, String FirstName, String LastName)>()
									 {
										 (cs.Year, Position: 1, FirstName: cs.First.FirstName(), LastName: cs.First.LastName()),
										 (cs.Year, Position: 2, FirstName: cs.Second.FirstName(), LastName: cs.Second.LastName()),
										 (cs.Year, Position: 3, FirstName: cs.Third.FirstName(), LastName: cs.Third.LastName())
									 }
									 select r;

			var query = (from r in Formula1.GetChampions()
									 join r2 in racers on (r.FirstName, r.LastName)
									 equals (r2.FirstName, r2.LastName)
									 into yearResults
									 select (r.FirstName, r.LastName, r.Wins, r.Starts, Results: yearResults
									 ));

			foreach(var r in query)
			{
				Console.WriteLine($"{r.FirstName} {r.LastName}");
				foreach(var results in r.Results)
					Console.WriteLine($"\t{results.Year} {results.Position}");
			}
		}

		static void InnerJoin()
		{
			var racers = from r in Formula1.GetChampions()
									 from y in r.Years
									 select new
									 {
										 Year = y,
										 Name = r.FirstName + " " + r.LastName
									 };
			var teams = from t in Formula1.GetConstructorChampions()
									from y in t.Years
									select new
									{
										Year = y,
										Name = t.Name
									};

			var racersAndTeam = (from r in racers
													 join t in teams on r.Year equals t.Year into rt
													 from t in rt.DefaultIfEmpty()
													 orderby r.Year
													 select new
													 {
														 r.Year,
														 Champion = r.Name,
														 Constructor = t==null ? "no constructor championship" : t.Name
													 }).Take(10);

			Console.WriteLine("Year World Champion\t Constructor Title");
			foreach(var item in racersAndTeam)
				Console.WriteLine($"{item.Year}: {item.Champion,-20} {item.Constructor}");
		}

		static void Grouping()
		{
			var countries = from r in Formula1.GetChampions()
											group r by r.Country into g
											orderby g.Count() descending, g.Key
											where g.Count() >= 2
											select new {
												Country = g.Key,
												Count = g.Count(),
												Racers=from r1 in g
															 orderby r1.LastName
															 select r1.FirstName + " " +  r1.LastName
											};

			foreach (var item in countries)
			{
				Console.WriteLine($"{item.Country,-10} {item.Count,2}");
				foreach (var racer in item.Racers)
					Console.WriteLine($"---{racer}");
			}
			
		}

		static void FerrariCar()
		{
			var query = Formula1.GetChampions()
				.SelectMany(r => r.Cars, (r, c) => new { Racer = r, Car = c })
				.Where(r => r.Car == "Ferrari")
				.OrderBy(r => r.Racer.LastName)
				.Select(r => r.Racer.LastName + " " + r.Racer.LastName);
			foreach(var racer in query)
				Console.WriteLine(racer);
		}

		static void TypeFiltering()
		{
			object[] data = { "one", 2, 3, "four", "five", 6 };
			var query = data.OfType<String>();

			foreach(var str in query)
				Console.WriteLine(str);
		}

		static void LINQQuery()
		{
			var query = from r in Formula1.GetChampions()
									where r.Country == "Brazil"
									orderby r.Wins descending
									select r;
			foreach(var r in query)
				Console.WriteLine($"{r:A}");
		}

		static void ExtensionMethods()
		{
			var champions = new List<Racer>(Formula1.GetChampions());
			IEnumerable<Racer> brazilChampions = champions
				.Where(r => r.Country == "Brazil")
				.OrderByDescending(r => r.Wins)
				.Select(r => r);

			foreach(var r in brazilChampions)
				Console.WriteLine($"{r:A}");
		}

		static void FilteringWithIndex()
		{
			var racers = Formula1.GetChampions()
				.Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);

			foreach(var racer in racers)
				Console.WriteLine($"{racer:A}");
		}
  }
}
