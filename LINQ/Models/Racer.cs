using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Models
{


	// Could you apply Builder pattern?
	public class Racer : IComparable<Racer>, IFormattable
	{
		public Racer(String firstName, String lastName, String country, Int32 starts, Int32 wins)
			: this(firstName, lastName, country, starts, wins, null, null)
		{

		}

		public Racer(String firstName, String lastName, String country, Int32 starts, Int32 wins,
			IEnumerable<Int32> years, IEnumerable<String> cars)
		{
			FirstName = firstName;
			LastName = lastName;
			Country = country;
			Starts = starts;
			Wins = wins;
			Years = years != null ? new List<Int32>(years) : new List<Int32>();
			Cars = cars != null ? new List<String>(cars) : new List<String>();
		}

		public String FirstName { get; }
		public String LastName { get; }
		public Int32 Wins { get; }
		public String Country { get; }
		public Int32 Starts { get; }
		public IEnumerable<Int32> Years { get; }
		public IEnumerable<String> Cars { get; }

		public override string ToString() => $"{FirstName} {LastName}";

		public int CompareTo(Racer other) => LastName.CompareTo(other?.LastName);

		public String ToString(String format) => ToString(format, null);

		public string ToString(String format, IFormatProvider formatProvider)
		{
			switch(format)
			{
				case null:
				case "N":
					return ToString();
				case "F":
					return FirstName;
				case "L":
					return LastName;
				case "C":
					return Country;
				case "S":
					return Starts.ToString();
				case "W":
					return Wins.ToString();
				case "A":
					return $"{FirstName} {LastName}, {Country}; starts: {Starts}, wins: {Wins}";
				default:
					throw new FormatException($"Format \"{format}\" not supported");
			}
		}
	}
}
