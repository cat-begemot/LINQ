using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Models
{
	public class Championship
	{
		public Championship(Int32 year, String first, String second, String third)
		{
			Year = year;
			First = first;
			Second = second;
			Third = third;
		}

		public Int32 Year { get; }
		public String First { get; }
		public String Second { get; }
		public String Third { get; }
	}
}
