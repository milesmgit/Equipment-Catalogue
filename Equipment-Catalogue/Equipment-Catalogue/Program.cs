﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace Equipment_Catalogue
{
	class Program
	{
		static void Main(string[] args)
		{

			try
			{
				string currentDirectory = Directory.GetCurrentDirectory();
				DirectoryInfo directory = new DirectoryInfo(currentDirectory);
				var fileName = Path.Combine(directory.FullName, "equipment.json");
				var fileName_favloot = Path.Combine(directory.FullName, "favoriteloot.json");
				// json data
				var equipmentList = DeserializeEquipment(fileName);

				// this list is for my attribute sort function sort_list: 
				var equipmentSort = DeserializeEquipment(fileName);

				// instantiate EquipmentCatalogue class from the JSON data 
				var equipmentCatalogue = new EquipmentCatalogue(equipmentList);


			



				// Introduction to the user
				Intro();

				// instantiate an Equipment type so that we can use its generic methods.
				var equipment = new Equipment();

				// instantiate sub-classes to use DetectEquipmentType method: In the future, I plan to extend this program to use the subclasses.
				var armor = new Armor("Armor");
				var shield = new Shield("Shield");
				var cloak = new Cloak("Cloak");

				// ensuring the variable is 'fresh'
				string searchResult = null;

				// Main Menu Search Instructions 
				MainMenuInstructions();

				// this bit gives formatting space to the console readline output
				Console.Write("		");
				searchResult = Console.ReadLine().ToLower();
				int list;

				// loop that controls menu
				while (searchResult != "quit")
				{
					// Using a try Parse to store searchResult into an int variable named list.
					if (Int32.TryParse(searchResult, out list))
					{
						if (list <= 5 && list >= 0)
						{

							if (list == 0)
							{
								// deserializing saved json data back into the program.
								var jsonPersist = DeserializeEquipment(fileName_favloot);
								// storing the persisted json data into a new EquipmentCatalogue.
								var equipmentCatalogue2 = new EquipmentCatalogue(jsonPersist);
								// method displays full list of equipment here
								equipmentCatalogue2.DisplayEquipmentCatalogue(equipmentCatalogue2);

							}
							else if (list == 1)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();

								Console.WriteLine($"		There are presently {equipmentCatalogue.NumberOfItems} items in the Equipment Catalogue.\n\n\n");

								// method displays full list of equipment here
								equipmentCatalogue.DisplayEquipmentCatalogue(equipmentCatalogue);
							}
							else if (list == 2)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								// displays list of armor here
								equipmentCatalogue.DetectEquipmentType(equipmentCatalogue, armor);

							}
							else if (list == 3)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								// displays list of shields here
								equipmentCatalogue.DetectEquipmentType(equipmentCatalogue, shield);

							}
							else if (list == 4)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();
								// displays list of cloaks here
								equipmentCatalogue.DetectEquipmentType(equipmentCatalogue, cloak);
							}
							else if (list == 5)
							{
								// base class method used to format text results
								equipment.GimmeSomeSpace();

								// instructions for searching by attribute
								RefinedMenuInstructions();

								// this gives formatting space to the readline output
								Console.Write("		");
								string refinedSearch = Console.ReadLine().ToLower();

								// base class method used to format text results
								equipment.GimmeSomeSpace();

								// allow user to return to main-menu
								if (refinedSearch == "main-menu".ToLower())
								{
									// program will loop back to main-menu by default.
								}
								else
								{
									// i'll add string matching later; for now this is workable solution. https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=netframework-4.7.2
									// i could use get index of, and if need be a ! operator; if refinedSearch not in the string array list, proceed
									if (refinedSearch != "Deflection".ToLower() && refinedSearch != "Armor".ToLower()
											&& refinedSearch != "Shield".ToLower() && refinedSearch != "AC Bonus".ToLower() &&
											refinedSearch != "Base AC".ToLower() && refinedSearch != "MAX DEX Bonus".ToLower() && refinedSearch != "Armor Check Penalty".ToLower() && refinedSearch != "Rare".ToLower() && refinedSearch != "BUR".ToLower() &&
											refinedSearch != "Dis".ToLower() && refinedSearch != "Min".ToLower())
									{
										Console.WriteLine("\n\n		That attribute is not in our database. Please make a new " +
											"selection.\n\n");
									}
									else
									{
										// this block aims to sort (best to worst) object instances in a list by AC_Bonus attribute.
										if (refinedSearch == "AC Bonus".ToLower())
										{
											var sorted_List = Sort_List(equipmentSort, refinedSearch);

											foreach (var piece in sorted_List)
											{
												// print out equipment profile
												Print_Sort(piece);
											}
											// this serializes the List to a JSON file.
											serialToJSON(sorted_List);

										}
										// this block aims to sort (best to worst) object instances in a list by MAX_DEX_Bonus attribute.
										else if (refinedSearch == "MAX DEX Bonus".ToLower())
										{
											var sorted_List = Sort_List(equipmentSort, refinedSearch);
											foreach (var piece in sorted_List)
											{
												// print out equipment profile
												Print_Sort(piece);
											}
											serialToJSON(sorted_List);
										}
										// this block aims to sort (best to worst) object instances in a list by Armor Check Penalty attribute.
										else if (refinedSearch == "Armor Check Penalty".ToLower())
										{
											var sorted_List = Sort_List(equipmentSort, refinedSearch);
											foreach (var piece in sorted_List)
											{
												// print out equipment profile
												Print_Sort(piece);
											}
											serialToJSON(sorted_List);
										}
										// this block aims to sort (best to worst) object instances in a list by AC_Bonus attribute.
										else if (refinedSearch == "Base AC".ToLower())
										{
											var sorted_List = Sort_List(equipmentSort, refinedSearch);
											foreach (var piece in sorted_List)
											{
												// print out equipment profile
												Print_Sort(piece);
											}
											serialToJSON(sorted_List);
										}
										else
										{
											// prints out list based on item attribute
											equipmentCatalogue.DisplayEquipmentCategory(equipmentCatalogue, refinedSearch);
										}
									}
								}
							}
						}
						else
						{
							Console.WriteLine("\n\n		Please Enter a Number Between 0-5.");
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
								Console.WriteLine("\n\n		Item not found. If you were trying to find an item by attribute,\n" +
									"\t\tfirst enter 5 and then type the name of the attribute.\n\n");
							}
						}
						else
						{
							Console.WriteLine("		Please choose a number from the list or enter an item name. [Not Case Sensitive]\n\n");
						}
					}
					// base class method used to format text results
					equipment.GimmeSomeSpace();

					searchResult = null;
					// prompt that will instruct a user to choose a list of items,
					// or will instruct the user to enter an item by name.


					// Main Menu Instructions
					MainMenuInstructions();

					// this gives formatting space to the readline output
					Console.Write("		");
					searchResult = Console.ReadLine().ToLower();
					// base class method used to format text results
					equipment.GimmeSomeSpace();
				}
			}
			// Test for 'null or empty string for Equipment_Name' is successful.
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
				// this gives formatting space to the readline output
				Console.Write("		");
				Console.Read();
			}
		}



		// deserialize a json file.
		// https://teamtreehouse.com/library/deserializing-with-jsonnet

		public static List<Equipment> DeserializeEquipment(string fileName)
		{
			var equipmentList = new List<Equipment>();
			var serializer = new JsonSerializer();
			using (var reader = new StreamReader(fileName))
			using (var jsonReader = new JsonTextReader(reader))
			{
				equipmentList = serializer.Deserialize<List<Equipment>>(jsonReader);
			}
			return equipmentList;
		}

		public static void RefinedMenuInstructions()
		{
			Console.WriteLine("		Enter an item attribute to return a list of matching items.\n" +
					"		Choose from the following list of item attributes. [Not Case Sensitive]\n\n" +
					"		[1] [AC Type:] <Type One of the Following AC Types>\n" +
					"   \t\t\t{Deflection, Armor, Shield}\n" +
					"		[2] [Attribute Sort : Best to Worst] <Type One of the Following Attributes>\n" +
					"   \t\t\t{AC Bonus, MAX DEX Bonus, Armor Check Penalty, Base AC}\n" +
					"		[3] [Can Be Found In Area:] <Type One of the Following Areas>\n" +
					"   \t\t\t{Rare, BUR, Dis, Min}\n\n" +
					"		Type 'main-menu' to return to the previous menu.\n\n\n");
		}


		public static void MainMenuInstructions()
		{
			Console.WriteLine("		Main Menu: \n\n\n" +
				"		Choose a list of items, or enter the name of the item directly. [Not Case Sensitive]\n\n" +
				"   \t\t[Enter 0 to Import Your Previously Saved Items From 'favoriteloot.json']\n" +
				"		[Enter 1 for a List of the Entire Equipment Catalogue]\n" +
				"		[Enter 2 for a List of Armor]\n" +
				"		[Enter 3 for a List of Shields]\n" +
				"		[Enter 4 for a List of Cloaks]\n" +
				"		[Enter 5 for a Refined Search by Equipment Attribute]\n\n" +
				"		[Type quit to terminate the program.]\n\n");
		}

		// this method passes in a class that contains an interface method for sorting; the method also take a string 'attribute' that 
		// will be passed into the class constructor so that various attributes may be sorted.
		public static List<Equipment> Sort_List(List<Equipment> equipmentSort, string attribute)
		{
			// this is the list we will return; it will hold sorted list data
			var sorted_List = new List<Equipment>();

			// instantiating a new instance of EquipmentSort class with the property 'Attribute' constructor
			// that allows for logic flow inside the method 'Compare' in the EquipmentSort class.
			equipmentSort.Sort(new EquipmentSort(attribute));

			foreach (var equipment in equipmentSort)
			{
				sorted_List.Add(equipment);
			}
			return sorted_List;
		}

		public static void Print_Sort(Equipment piece)
		{
			Console.WriteLine($"		Item ID: {piece.Equipment_ID}\n" +
													$"		Item Name: {piece.Equipment_Name}\n" +
													$"		Item Type: {piece.Equipment_Type}\n" +
													$"		Item Armor Class Type: {piece.AC_Type}\n" +
													$"		Item Known Location(s): {piece.Can_Be_Found_In_Area}\n" +
													$"		Item Armor Class Bonus: {piece.AC_Bonus}\n" +
													$"		Item Maximum Dexterity Bonus: {piece.MAX_DEX_Bonus}\n" +
													$"		Item Base Armor Class: {piece.Base_AC}\n" +
													$"		Item Armor Check Penalty: {piece.Armor_Check_Penalty}\n\n");
		}

		// in hindsight, i should have used tab characters instead of spaces methinks.  oh well, it works fine atm.  I may fix later just for organization purposes.
		public static void Intro()
		{
			Console.WriteLine("\n\n\n" + "                         )                           ****+****\n" +
					"		        (                            **+++++**\n" +
					"		+0)))))(+)>>>>>>>>>>>>>>>>>>>>        ***+***\n" +
					"		        (                              **+**\n" +
					"                         )                              *+*\n\n" +
					"		Hello, and welcome to the HG Equipment Catalogue Manager!\n\n" +
					"		This program's purpose is to provide a searchable database of the module's \n" +
					"		gear. The aim is to make it easier to build characters due to possessing a foreknowledge\n" +
					"		of item drops. You can search the entire equipment catalogue at once, or by categories.\n\n" +
					"		I hope you find the program easy to use, and please do offer suggestions for improving\n" +
					"		your user experience. Happy hunting -- Miles\n\n");
		}


		// method to write to file (serialize json)
		public static void SerializeEquipmentToFile(List<Equipment> equipmentList, string fileName)
		{

			var serializer = new JsonSerializer();
			using (var writer = new StreamWriter(fileName))
			using (var jsonWriter = new JsonTextWriter(writer))
			{
				serializer.Serialize(jsonWriter, equipmentList);
			}
		}

		// this method will store user search to json file, for retrieval at any time, during, or upon next start of program.
		public static void serialToJSON(List<Equipment> sorted_List)
		{
				var printToFile = "";
				Console.WriteLine("\t\tPrint to File 'favoriteloot.json'? Note: This will Overwrite the File!  <Type: y or n>\n\n");
				Console.Write("\t\t");
				printToFile = Console.ReadLine();

				if (printToFile == "y")
				{
				// serialize json file
				string currentDirectory = Directory.GetCurrentDirectory();
				DirectoryInfo directory = new DirectoryInfo(currentDirectory);
				var fileNameOut = Path.Combine(directory.FullName, "favoriteloot.json");
					SerializeEquipmentToFile(sorted_List, fileNameOut);
					Console.WriteLine("\n\n\t\tYour selection has been saved.");
				}
				else
				{
					Console.WriteLine("\n\n\t\tYour selection has not been saved.");
				}

		}



	





	}
}
