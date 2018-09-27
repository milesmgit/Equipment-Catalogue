using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Equipment_Catalogue
{
	public class Shield : Equipment
	{

		// For those properties with private setters, I will use the auto-implemented property in case the property value needs to be changed; I can change the class properties
		// from within the class, and the resulting behavior is the same from outside the class.






		// default constructor for use in my subclass detector method
		public Shield(string equipment_Type) : base(equipment_Type)
		{

		}

		// constructor for the Shield class that will get the values of the instances passed into the base class <Equipment>.
		public Shield(int equipment_ID, string equipment_Name, string equipment_Type,
										string aC_Type, string can_Be_Found_In_Area, int aC_Bonus, int mAX_DEX_Bonus,
										int base_AC, int armor_Check_Penalty)
			: base(equipment_ID, equipment_Name, equipment_Type, aC_Type, can_Be_Found_In_Area, aC_Bonus,
							mAX_DEX_Bonus, base_AC, armor_Check_Penalty)
		{
			
		}



	



	}
}
