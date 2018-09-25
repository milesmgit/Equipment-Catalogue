// the purpose of this project will be to create a dataset, read(import) the dataset 
// into this program so that specific items may be searched according to various
// item attributes input from the user.  Then the results of the search will be
// persisted to a database so that the user may return to the data at a later time.
// The utility to the user will be that of making it easier to decide which gear to 
// don based upon current player character attributes possessed or missing.
// It will be much easier to design an optimum character for future use if the 
// equipment gearset is known.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Catalogue
{

	// this is my base class for the derived item subclasses
	public class Equipment
	{
		// Property Structure: <access modifier> <data-type> <Property Name> <{get; set;}>


		// For those properties with private setters, I will use the auto-implemented property in case the property value needs to be changed; I can change the class properties
		// from within the class, and the resulting behavior is the same from outside the class.


		public int Equipment_ID { get; private set; }



		public string Equipment_Name { get; private set; }


		// equipment type:  armor, cloak, shield etc...
		public string Equipment_Type { get; private set; }

		// armor class type:  dodge, shield, deflection, armor, natural
		public string AC_Type { get; private set; }

		// can be found in area:  either a set drop from a specific area, or random drop and type of random. rare, BUR etc...)
		public string Can_Be_Found_In_Area { get; private set; }

		// amount of armor class bonus, if any provided by the item
		public int AC_Bonus { get; private set; }

		// maximum benefit that can be gained from your character's dexterity modifier: 100 is limit for those items that don't have a max dex bonus
		public int MAX_DEX_Bonus { get; private set; }


		// setting a default constructor for the Equipment base class for use when calling generic methods.
		public Equipment()
		{

		}


		// base constructor for use in my subclass detector method
		public Equipment(string equipment_Type)
		{
			Equipment_Type = equipment_Type;
		}

		// setting a constructor for the equipment class that will be used to pass shared properties
		// to derived subclasses.

		public Equipment(int equipment_ID, string equipment_Name, string equipment_Type,
											string aC_Type, string can_Be_Found_In_Area, int aC_Bonus,
											int mAX_DEX_Bonus)
		{

			// using an if statement to throw an exception if our piece of equipment
			// doesn't have an equpment_Name passed to our Base class constructor.
			if (string.IsNullOrEmpty(equipment_Name))
			{

				throw new Exception("An Equipment Type must have a Name.");

			}
			// this sets base and sub class properties from parameter values passed to the base class constructor.
			Equipment_ID = equipment_ID;
			Equipment_Name = equipment_Name;
			Equipment_Type = equipment_Type;
			AC_Type = aC_Type;
			Can_Be_Found_In_Area = can_Be_Found_In_Area;
			AC_Bonus = aC_Bonus;
			MAX_DEX_Bonus = mAX_DEX_Bonus;
		}

		// creating a virtual method that will return a series of strings containing various bits of information about the 
		// Equipment item it is virtual so that it may be overriden by the extended derived classes as their needs change.
		// this method would be used like so:    someInstance.GetEquipmentProfile();
		public virtual void GetEquipmentProfile()
		{
			Console.WriteLine($"Item ID: {Equipment_ID}");
			Console.WriteLine($"Item Name: {Equipment_Name}");
			Console.WriteLine($"Item Type: {Equipment_Type}");
			Console.WriteLine($"Item Armor Class Type: {AC_Type}");
			Console.WriteLine($"Item Known Location(s): {Can_Be_Found_In_Area}");
			Console.WriteLine($"Item Armor Class Bonus: {AC_Bonus}");
			Console.WriteLine($"Item Maximum Dexterity Bonus: {MAX_DEX_Bonus}");

		}

		// method to give space between method calls  [purpose: formatting]
		public void GimmeSomeSpace()
		{
			Console.WriteLine("\n");
		}

	}
}
