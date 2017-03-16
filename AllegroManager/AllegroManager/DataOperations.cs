using System;
using System.Text.RegularExpressions;
namespace AllegroManager
{
	public class DataOperations
	{
		public string RemoveSunday(string description)
		{
			string part1 = Regex.Replace(description, "nie 10-15", "");
			string output = Regex.Replace(part1, "NIE 10:00 - 15:00", "");

			return output;
		}
	}
}
