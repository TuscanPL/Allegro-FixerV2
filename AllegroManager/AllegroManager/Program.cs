using System;

namespace AllegroManager
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			UserData ud = new UserData();
			DataOperations dataOp = new DataOperations();
			var array = ud.getItemIDs();
			Console.WriteLine("\n");
			int counter = 0;
			/*
			foreach (var item in array)
			{
				Console.WriteLine("{0} [{1}/{2}]", item, counter, array.Length);
				counter++;
				var temp = ud.getItemFieldValues(item);
				temp[14].fvaluestring = dataOp.RemoveSunday(temp[14].fvaluestring);
				ud.setItemDescription(item, temp);
			}
			*/

			Console.WriteLine("{0} [{1}/{2}]", array[5], counter, array.Length);
			counter++;
			var temp = ud.getItemFieldValues(array[5]);
			temp[14].fvaluestring = dataOp.RemoveSunday(temp[14].fvaluestring);
			ud.setItemDescription(array[5], temp);

		}
	}
}
