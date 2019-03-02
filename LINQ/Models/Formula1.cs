using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Models
{
	public static class Formula1
	{
		private static List<Racer> s_racers;

		public static IList<Racer> GetChampions() => s_racers ?? (s_racers = InitializeRacers());

		private static List<Racer> InitializeRacers() =>
			new List<Racer>()
			{
				new Racer("Nino", "Farina", "Italy", 33, 5, new int[] { 1950 }, new string[] { "Alfa Romeo" }),
				new Racer("Alberto", "Ascari", "Italy", 32, 13, new int[] { 1952, 1953 }, new string[] { "Ferrari" }),
				new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24, new int[] { 1951, 1954, 1955, 1956, 1957 }, new string[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" }),
				new Racer("Mike", "Hawthorn", "UK", 45, 3, new int[] { 1958 }, new string[] { "Ferrari" }),
				new Racer("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }),
				new Racer("John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }),
				new Racer("Jim", "Clark", "UK", 72, 25, new int[] { 1963, 1965 }, new string[] { "Lotus" }),
				new Racer("Jack", "Brabham", "Australia", 125, 14, new int[] { 1959, 1960, 1966 }, new string[] { "Cooper", "Brabham" }),
				new Racer("Denny", "Hulme", "New Zealand", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }),
				new Racer("Graham", "Hill", "UK", 176, 14, new int[] { 1962, 1968 }, new string[] { "BRM", "Lotus" }),
				new Racer("Jochen", "Rindt", "Austria", 60, 6, new int[] { 1970 }, new string[] { "Lotus" }),
				new Racer("Jackie", "Stewart", "UK", 99, 27, new int[] { 1969, 1971, 1973 }, new string[] { "Matra", "Tyrrell" }),
				new Racer("Emerson", "Fittipaldi", "Brazil", 143, 14, new int[] { 1972, 1974 }, new string[] { "Lotus", "McLaren" }),
				new Racer("James", "Hunt", "UK", 91, 10, new int[] { 1976 }, new string[] { "McLaren" }),
				new Racer("Mario", "Andretti", "USA", 128, 12, new int[] { 1978 }, new string[] { "Lotus" }),
				new Racer("Jody", "Scheckter", "South Africa", 112, 10, new int[] { 1979 }, new string[] { "Ferrari" }),
				new Racer("Alan", "Jones", "Australia", 115, 12, new int[] { 1980 }, new string[] { "Williams" }),
				new Racer("Keke", "Rosberg", "Finland", 114, 5, new int[] { 1982 }, new string[] { "Williams" }),
				new Racer("Niki", "Lauda", "Austria", 173, 25, new int[] { 1975, 1977, 1984 }, new string[] { "Ferrari", "McLaren" }),
				new Racer("Nelson", "Piquet", "Brazil", 204, 23, new int[] { 1981, 1983, 1987 }, new string[] { "Brabham", "Williams" }),
				new Racer("Ayrton", "Senna", "Brazil", 161, 41, new int[] { 1988, 1990, 1991 }, new string[] { "McLaren" }),
				new Racer("Nigel", "Mansell", "UK", 187, 31, new int[] { 1992 }, new string[] { "Williams" }),
				new Racer("Alain", "Prost", "France", 197, 51, new int[] { 1985, 1986, 1989, 1993 }, new string[] { "McLaren", "Williams" }),
				new Racer("Damon", "Hill", "UK", 114, 22, new int[] { 1996 }, new string[] { "Williams" }),
				new Racer("Jacques", "Villeneuve", "Canada", 165, 11, new int[] { 1997 }, new string[] { "Williams" }),
				new Racer("Mika", "Hakkinen", "Finland", 160, 20, new int[] { 1998, 1999 }, new string[] { "McLaren" }),
				new Racer("Michael", "Schumacher", "Germany", 287, 91, new int[] { 1994, 1995, 2000, 2001, 2002, 2003, 2004 }, new string[] { "Benetton", "Ferrari" }),
				new Racer("Fernando", "Alonso", "Spain", 314, 32, new int[] { 2005, 2006 }, new string[] { "Renault" }),
				new Racer("Kimi", "Räikkönen", "Finland", 294, 21, new int[] { 2007 }, new string[] { "Ferrari" }),
				new Racer("Lewis", "Hamilton", "UK", 229, 73, new int[] { 2008, 2014, 2015, 2017, 2018 }, new string[] { "McLaren", "Mercedes" }),
				new Racer("Jenson", "Button", "UK", 306, 16, new int[] { 2009 }, new string[] { "Brawn GP" }),
				new Racer("Sebastian", "Vettel", "Germany", 220, 52, new int[] { 2010, 2011, 2012, 2013 }, new string[] { "Red Bull Racing" }),
				new Racer("Nico", "Rosberg", "Germany", 207, 24, new int[] { 2016 }, new string[] { "Mercedes" })
			};

		private static List<Team> s_teams;
		public static IList<Team> GetConstructorChampions()
		{
			if(s_teams==null)
			{
				s_teams = new List<Team>()
				{
					new Team("Vanwall", 1958),
					new Team("Cooper", 1959, 1960),
					new Team("Ferrari", 1961, 1964, 1975, 1976, 1977, 1979, 1982, 1983, 1999, 2000, 2001, 2002, 2003, 2004, 2007, 2008),
					new Team("BRM", 1962),
					new Team("Lotus", 1963, 1965, 1968, 1970, 1972, 1973, 1978),
					new Team("Brabham", 1966, 1967),
					new Team("Matra", 1969),
					new Team("Tyrrell", 1971),
					new Team("McLaren", 1974, 1984, 1985, 1988, 1989, 1990, 1991, 1998),
					new Team("Williams", 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996, 1997),
					new Team("Benetton", 1995),
					new Team("Renault", 2005, 2006 ),
					new Team("Brawn GP", 2009),
					new Team("Red Bull Racing", 2010, 2011, 2012, 2013),
					new Team("Mercedes", 2014, 2015, 2016, 2017, 2018)
				};
			}
			return s_teams;
		}


	}
}
