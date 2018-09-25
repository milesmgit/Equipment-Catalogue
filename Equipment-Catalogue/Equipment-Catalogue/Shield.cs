using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Catalogue
{
	public class Shield : Equipment
	{

		// For those properties with private setters, I will use the auto-implemented property in case the property value needs to be changed; I can change the class properties
		// from within the class, and the resulting behavior is the same from outside the class.



		// properties unique to the shield class in relation to the base class.
		public int Base_AC { get; private set; }
		public int Armor_Check_Penalty { get; private set; }


		// default constructor for use in my subclass detector method
		public Shield(string equipment_Type) : base(equipment_Type)
		{

		}

		// constructor for the Shield class that will get the values of the instances passed into the base class <Equipment>.
		public Shield(int equipment_ID, string equipment_Name, string equipment_Type,
										string aC_Type, string can_Be_Found_In_Area, int aC_Bonus, int mAX_DEX_Bonus,
										int base_AC, int armor_Check_Penalty)
			: base(equipment_ID, equipment_Name, equipment_Type, aC_Type, can_Be_Found_In_Area, aC_Bonus,
							mAX_DEX_Bonus)
		{
			Base_AC = base_AC;
			Armor_Check_Penalty = armor_Check_Penalty;
		}



		// creating an override method that will return a series of strings containing various bits of information about the Armor item.
		// This override method extends the base method of the same name, and adds information as the unique derived class requires.

		public override void GetEquipmentProfile()
		{
			// calling the base class GetEquipmentProfile method:
			base.GetEquipmentProfile();

			// Adding to the base method extra information as is unique to the derived class.
			Console.WriteLine($"Item Base Armor Class: {Base_AC}");
			Console.WriteLine($"Item Armor Check Penalty: {Armor_Check_Penalty}");
		}




	}
}
