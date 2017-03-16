using System;
using AllegroManager.webapi.allegro.pl;
using System.Collections.Generic;
using System.Linq;
namespace AllegroManager
{
	public class UserData
	{
		private object[] allegroData()
		{
			// 0 = ApiKey, 1 = userId, 2 = sessionId, 3 = countryId
			var al = new AllegroWebApiService();
			int countryId = 1;
			string webapiKey = "6150b1ae";
			long verKey;
			long userId;
			long serverTime;
			var sysStatus = al.doQuerySysStatus(1, countryId, webapiKey, out verKey);
			string sessionHandle = al.doLogin("24game", "zelda1234", countryId, webapiKey, verKey, out userId, out serverTime);
			object[] workData = new object[4];
			workData[0] = webapiKey;
			workData[1] = userId;
			workData[2] = sessionHandle;
			workData[3] = countryId;

			return workData;
		}

		public long[] getItemIDs()
		{
			var userData = allegroData();
			var al = new AllegroWebApiService();
			var sort = new SortOptionsStruct { sorttype = 3, sortorder = 1 };
			var filter = new SellFilterOptionsStruct { };
			string searchValue = "";
			int categoryId = 0;
			long[] itemIds = null;
			int pageSize = 800;
			int pageNumber = 0;
			SellItemStruct[] sellItems;

			int itemCount = al.doGetMySellItems(userData[2].ToString(), sort, filter, searchValue, categoryId, itemIds, pageSize, pageNumber, out sellItems);

			Console.WriteLine("Currently we're selling " + itemCount + " things");
			List<long> idList = new List<long>();
			foreach (var item in sellItems)
			{
				if (item.itemsoldquantity < 1)
				{
					idList.Add(item.itemid);
				}
				else
				{
					Console.WriteLine(item.itemtitle);
				}
			}

			return idList.ToArray();
		}

		public string[] getItemTitles()
		{
			var userData = allegroData();
			var al = new AllegroWebApiService();
			var sort = new SortOptionsStruct { sorttype = 3, sortorder = 1 };
			var filter = new SellFilterOptionsStruct { };
			string searchValue = "";
			int categoryId = 0;
			long[] itemIds = null;
			int pageSize = 800;
			int pageNumber = 0;
			SellItemStruct[] sellItems;

			int itemCount = al.doGetMySellItems(userData[2].ToString(), sort, filter, searchValue, categoryId, itemIds, pageSize, pageNumber, out sellItems);

			Console.WriteLine("Currently we're selling " + itemCount + " things");
			List<string> idList = new List<string>();
			foreach (var item in sellItems)
			{
				if (item.itemsoldquantity < 1)
				{
					idList.Add(item.itemtitle);
				}
				else
				{
					Console.WriteLine(item.itemtitle);
				}
			}

			return idList.ToArray();
		}

		public FieldsValue[] getItemFieldValues(long itemId)
		{
			var userData = allegroData();
			var al = new AllegroWebApiService();

			var itemFields = al.doGetItemFields(userData[2].ToString(), itemId);

			return itemFields;
		}

		public void setItemDescription(long itemId, FieldsValue[] fv)
		{
			var al = new AllegroWebApiService();
			var userData = allegroData();
			al.doChangeItemFields(userData[2].ToString(), itemId, fv, null, 0, null, null);
			Console.WriteLine(itemId + " changed.");
		}
	}
}
