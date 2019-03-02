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
			LINQQuery();
			Console.WriteLine("-----");
			ExtensionMethods();
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
  }
}
