using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Equipment_Catalogue
{
	public class Cloak : Equipment
	{




		// constructor for use in my subclass detector method
		public Cloak(string equipment_Type) : base(equipment_Type)
		{

		}


		// constructor for the Cloak class that will get the values of the instances passed into the base class <Equipment>.
		public Cloak(int equipment_ID, string equipment_Name, string equipment_Type,
										string aC_Type, string can_Be_Found_In_Area, int aC_Bonus, int mAX_DEX_Bonus, int base_AC, int armor_Check_Penalty)
			: base(equipment_ID, equipment_Name, equipment_Type, aC_Type, can_Be_Found_In_Area, aC_Bonus,
							mAX_DEX_Bonus, base_AC, armor_Check_Penalty)
		{

		}



		// original project solution has the override and virtual methods for use with subclasses, in addition
		// to some custom properties.  Can't use those yet, until I learn how to deserialize into various
		// sub-classes all at once; unless i want to rewrite the methods and classes to account
		// for using for loops to add sub-classes to an equipment catalogue.  Food for thought.

	}
}
