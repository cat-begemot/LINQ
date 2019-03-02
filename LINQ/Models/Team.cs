using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Models
{
	public class Team
	{
		public Team(String name, params int[] years)
		{
			Name = name;
			Years = years != null ? new List<Int32>(years) : new List<Int32>();
		}

		public String Name { get; }
		public IEnumerable<Int32> Years { get; }
	}
}
