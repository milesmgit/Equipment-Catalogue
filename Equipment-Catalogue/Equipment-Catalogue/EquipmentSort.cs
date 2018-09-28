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
		public int Compare(Equipment x, Equipment y)
		{
			return x.AC_Bonus.CompareTo(y.AC_Bonus);
		}
		
	}


	// will add various sort nested classes, to be used as methods that sort various attributes.


}
