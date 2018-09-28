using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Catalogue
{

	// https://teamtreehouse.com/library/top-ten-scorers
	// the above link topic covers sorting and using IComparer Interface.
	// this method will be used to list the items by lowest to highest ac bonus.
	public class EquipmentSort : IComparer<Equipment>
	{

		public string Attribute { get; set; }

		public EquipmentSort(string attribute)
		{
			Attribute = attribute;

		}

		// this method takes a string from the class constructor, and passes it into the
		// logic; the goal is to print out sorted lists based upon input attribute string.
		public int Compare(Equipment x, Equipment y)
		{
			if (Attribute == "AC Bonus".ToLower())
			{
				return x.AC_Bonus.CompareTo(y.AC_Bonus);
			}
			else if (Attribute == "MAX DEX Bonus".ToLower())
			{
				return x.MAX_DEX_Bonus.CompareTo(y.MAX_DEX_Bonus);
			}
			else if (Attribute == "Armor Check Penalty".ToLower())
			{
				return x.Armor_Check_Penalty.CompareTo(y.Armor_Check_Penalty);
			}
			else if (Attribute == "Base AC".ToLower())
			{
				return x.Base_AC.CompareTo(y.Base_AC);
			}
			return 0;
		}
		
	}


	// will add attributes later:  deflection etc...ill use this to get list of items based upon attribute, public void DisplayEquipmentCategory(EquipmentCatalogue _list, string criteria)
	// and then use the above to sort based upon ac bonus.


}
