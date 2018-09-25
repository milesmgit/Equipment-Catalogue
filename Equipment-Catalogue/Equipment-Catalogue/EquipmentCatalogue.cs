﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Catalogue
{
	class EquipmentCatalogue
	{
		// private means that this field can only be accessed from within this class.
		// This means that if you want to use this field, you will need to have an instance 
		// of this class so that you can access.
		private Equipment[] _items;

		// computed property, using an expresion body, for number of items in the Equipment[] array
		public int NumberOfItems => _items.Length;

		// public constructor that takes an array of Equipment items and sets the private 
		// field to that value. // I plan to pass in JSON data to this constructor.
		public EquipmentCatalogue(Equipment[] items)
		{
			_items = items;
		}

		// method that will return an item based upon an Equipment Name Search
		public Equipment FindItem(string criteria)
		{
			Equipment itemToReturn = null;
			foreach (var item in _items)
			{
				if (item.Equipment_Name.ToLower().Contains(criteria.ToLower()))
				{
					itemToReturn = item;

				}
			}
			return itemToReturn;
		}

		// method that will return a list of items based upon their item type, chosen from 
		// a list.
		// method that will list the equipment profile of each item in the equipmentCatalogue
		// to the console. I'm using the computed property 'NumberOfItems' in place of _items.Length.
		public void DisplayEquipmentCategory(EquipmentCatalogue _items, string criteria)
		{
			for (int i = 0; i < NumberOfItems; i++)
			{
				if (_items.GetItemAt(i).AC_Type.ToLower().Contains(criteria.ToLower()))
				{
					// this method would be used like so:    someInstance.GetEquipmentProfile();
					_items.GetItemAt(i).GetEquipmentProfile();
					Console.WriteLine("\n\n");
				}
				else if (_items.GetItemAt(i).Can_Be_Found_In_Area.ToLower().Contains(criteria.ToLower()))
				{
					// this method would be used like so:    someInstance.GetEquipmentProfile();
					_items.GetItemAt(i).GetEquipmentProfile();
					Console.WriteLine("\n\n");
				}
			}
		}


		// method that will list the equipment profile of each item in the equipmentCatalogue
		// to the console. I'm using the computed property 'NumberOfItems' in place of _items.Length.
		public void DisplayEquipmentCatalogue(EquipmentCatalogue _items)
		{
			for (int i = 0; i < NumberOfItems; i++)
			{

				// this method would be used like so:    someInstance.GetEquipmentProfile();
				_items.GetItemAt(i).GetEquipmentProfile();
				Console.WriteLine("\n\n");
			}
		}

		// creating a method that will return a specific Equipment item from the 
		// Equipment[] _items array.
		public Equipment GetItemAt(int index)
		{
			if (index >= 0 && index < _items.Length)
			{
				return _items[index];
			}
			else
			{
				Console.WriteLine("An element at index " + index + " doesn't exist in the Equipment Catalogue.");
				return null;
			}
		}

		// creating a detect Equipment Type static method and then passing in the various 
		// Equipment types as parameters.  This program will print out the profile of the specific
		// equipment types inputted by the user.
		// we will call this from the main method and pass in various Equipment Types, and the
		// equipment catalogue.
		public void DetectEquipmentType(EquipmentCatalogue _items, Equipment equipmentItem)
		{
			for (var i = 0; i < NumberOfItems; i++)
			{
				// short-circuiting the method if the item parameter is null
				if (equipmentItem == null)
				{
					return;
				}
				if (equipmentItem is Armor && _items.GetItemAt(i).Equipment_Type == "Armor")
				{
					Console.WriteLine(_items.GetItemAt(i).Equipment_Name + " is of Equipment Type: Armor");
					// this method would be used like so:    someInstance.GetEquipmentProfile();
					_items.GetItemAt(i).GetEquipmentProfile();
					Console.WriteLine("\n\n");
				}
				if (equipmentItem is Shield && _items.GetItemAt(i).Equipment_Type == "Shield")
				{
					Console.WriteLine(_items.GetItemAt(i).Equipment_Name + " is of Equipment Type: Shield");
					// this method would be used like so:    someInstance.GetEquipmentProfile();
					_items.GetItemAt(i).GetEquipmentProfile();
					Console.WriteLine("\n\n");
				}
				if (equipmentItem is Cloak && _items.GetItemAt(i).Equipment_Type == "Cloak")
				{
					Console.WriteLine(_items.GetItemAt(i).Equipment_Name + " is of Equipment Type: Cloak");
					// this method would be used like so:    someInstance.GetEquipmentProfile();
					_items.GetItemAt(i).GetEquipmentProfile();
					Console.WriteLine("\n\n");
				}
				// i will look into making a fail safe later, in case an unrecognized subtype is encountered.
				// it works thus far as is, so I'm moving on to satisfying course requirements as priority.
			}
		}



	}
}
