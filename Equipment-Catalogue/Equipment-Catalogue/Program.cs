using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Catalogue
{
	class Program
	{
		static void Main(string[] args)
		{

			try
			{

				// Introduction to the user:
				Console.WriteLine("Hello, and welcome to the HG-Equipment Catalogue Manager!\n\n"+
					"This program's purpose is to provide a searchable database of the module's " +
					"gear.\nThe aim is to make it easier to build characters due to possessing a foreknowledge\n" +
					"of item drops. You can search the entire equipment catalogue at once, or by categories.\n\n" +
					"I hope you find the program easy to use, and please do offer suggestions for improving\n" +
					"your user experience. Happy hunting -- Miles\n\n\n");

				// instantiate an Equipment type so that we can use its generic methods.
				var equipment = new Equipment();

				// instantiate the armor, shield, and cloak types for use in my subtype detector method
				var armor = new Armor("Armor");
				var shield = new Shield("Shield");
				var cloak = new Cloak("Cloak");


				// instantiate EquipmentCatalogue class and assign it values.
				var equipmentCatalogue = new EquipmentCatalogue(new Equipment[]
				{
						new Armor(1, "Thor's Armor", "Armor",
														"Armor AC", "BUR", 20,
														100, 0, 0),
						new Armor(2, "Miles Armor", "Armor",
														"Armor AC", "BUR", 19,
														100, 0, 0),
						new Cloak(3, "Cloak of Protection", "Cloak",
													"Deflection AC", "Abyss Pit", 20, 100),
						new Cloak(4, "Cloak of the Blessed", "Cloak",
													"Deflection AC", "Dustbone's Lair", 18, 100),
						new Shield(5, "Shield of the Watch", "Shield",
													"Shield AC", "Rare", 14, 22, 1, 2)
				});




				string searchResult = null;
				// Provide user with option to enter search criteria for specific items.
				// Eventually, I would like the Equipment Catalogue to be searched by 
				// each of the various categories.  I will add as time allows.

				// prompt that will instruct a user to choose a list of items,
				// or will instruct the user to enter an item by name.

				Console.WriteLine("Main Menu: \n\n\nChoose a list of items,\nor enter the name of the item directly. [Not Case Sensitive]\n\n");
				Console.WriteLine("[Enter 1 for a List of the Entire Equipment Catalogue]\n" +
					"[Enter 2 for a List of Armor]\n[Enter 3 for a List of Shields]\n" +
					"[Enter 4 for a List of Cloaks]\n" +
					"[Enter 5 for a Refined Search by Equipment Attribute]\n\n" +
					"[Type quit to terminate the program.]\n\n");


				searchResult = Console.ReadLine().ToLower();
				int list;
				Int32.TryParse(searchResult, out list);

				while (searchResult != "quit")
				{
					// find subtype item in Equipment Catalogue method using ConsoleReadLine
					// to gather user input.
					// Using a try Parse to store searchResult into an int variable named list.

					if (Int32.TryParse(searchResult, out list))
					{
						if (list <= 5 && list > 0)
						{
							if (list == 1)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								//// calling from equipmentCatalogue the NumberOfItems computed property.
								Console.WriteLine($"There are presently {equipmentCatalogue.NumberOfItems} items in the Equipment Catalogue.\n\n\n");
								// add list of equipment here
								equipmentCatalogue.DisplayEquipmentCatalogue(equipmentCatalogue);
							}
							else if (list == 2)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								// add list of armor here
								equipmentCatalogue.DetectEquipmentType(equipmentCatalogue, armor);

							}
							else if (list == 3)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								// add list of shields here
								equipmentCatalogue.DetectEquipmentType(equipmentCatalogue, shield);

							}
							else if (list == 4)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								// add list of cloaks here
								equipmentCatalogue.DetectEquipmentType(equipmentCatalogue, cloak);
							}
							else if (list == 5)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();

								Console.WriteLine("Enter an item attribute to return a list of matching items.\n" +
									"Choose from the following list of item attributes. [Not Case Sensitive]\n\n" +
									"[1] [AC_Type: Deflection, Natural, Armor, Dodge, Shield]\n" +
									"[2] [Can_Be_Found_In_Area: <Type an Area> Rare, BUR, Avernus, Dis, Min]\n\n");
								Console.WriteLine("Type 'main-menu' to return to the previous menu.\n\n\n");
								string refinedSearch = Console.ReadLine().ToLower();
								if (refinedSearch == "main-menu".ToLower())
								{
									Console.WriteLine("\n\nMain Menu:");
								}
								else
								{
									// i'll add string matching later; for now this is workable solution. https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=netframework-4.7.2
									if (refinedSearch != "Deflection".ToLower() && refinedSearch != "Natural".ToLower() && refinedSearch != "Armor".ToLower()
											&& refinedSearch != "Dodge".ToLower() && refinedSearch != "Shield".ToLower() &&
											refinedSearch != "Rare".ToLower() && refinedSearch != "BUR".ToLower() &&
											refinedSearch != "Avernus".ToLower() && refinedSearch != "Dis".ToLower()
											&& refinedSearch != "Min".ToLower())
									{
										Console.WriteLine("\n\nThat attribute is not in our database. Please make a new " +
											"selection.\n\n");
									}
									else
									{
										// method that will list the equipment profile of each item in the equipmentCatalogue
										// to the console. I'm using the computed property 'NumberOfItems' in place of _items.Length.
										equipmentCatalogue.DisplayEquipmentCategory(equipmentCatalogue, refinedSearch);
									}
								}
							}
						}
						else
						{
							Console.WriteLine("Please Enter a Number Between 1-5.");
						}
					}
					else
					{
						if (searchResult != "" && searchResult != null)
						{
							var item = equipmentCatalogue.FindItem(searchResult);

							if (item != null)
							{
								// we subtract one from the item ID because the index starts at 0.
								int i = item.Equipment_ID - 1;

								// this method would be used like so:    someInstance.GetEquipmentProfile();
								equipmentCatalogue.GetItemAt(i).GetEquipmentProfile();
								Console.WriteLine("\n\n");
							}
							else
							{
								Console.WriteLine("Item not found. If you were trying to find an item by attribute " +
									"first enter 5 and then type the name of the attribute.\n\n");
							}
						}
						else
						{
							Console.WriteLine("Please enter an item name or choose a number from the list.\n\n");
						}
					}
					// base class method used to format text results
					equipment.GimmeSomeSpace();
					searchResult = null;
					// prompt that will instruct a user to choose a list of items,
					// or will instruct the user to enter an item by name.

					Console.WriteLine("Choose a list of items,\nor enter the name of the item directly.\n\n");
					Console.WriteLine("[Enter 1 for a List of the Entire Equipment Catalogue]\n" +
						"[Enter 2 for a List of Armor]\n[Enter 3 for a List of Shields]\n" +
						"[Enter 4 for a List of Cloaks]\n" +
						"[Enter 5 for a Refined Search by Equipment Attribute]\n\n" +
						"[Type quit to terminate the program.]\n\n");
					searchResult = Console.ReadLine().ToLower();
					// base class method used to format text results
					equipment.GimmeSomeSpace();

				}






			}
			// Test for 'null or empty string for Equipment_Name' is successful.
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
				Console.Read();

			}
		}







	}
}
