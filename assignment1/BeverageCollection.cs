//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageCollection
    {
        //Private Variables
        Beverages[] beverage;
        int wineItemsLength;

        BeverageKShermanEntities BeverageEntities = new BeverageKShermanEntities();
        //Console.WriteLine("Print the list");

        //Constuctor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            beverage = new Beverages[size];
            wineItemsLength = 0;
        }

        public void processLine()
        {
            foreach (Beverage beverage in BeverageEntities.Beverages)
            {
                AddNewItem(beverage.id, beverage.name, beverage.pack, beverage.price, beverage.active);
            }
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack, decimal price, bool active)
        {
            //Add a new WineItem to the collection. Increase the Length variable.
            beverage[wineItemsLength] = new Beverages(id, description, pack, price, active);
            
            wineItemsLength++;
        }

        public void AddToDatabase(string id, string description, string pack, decimal price, bool active)
        {
            Beverage newBeverageToAdd = new Beverage();
            newBeverageToAdd.id = id;
            newBeverageToAdd.name = description;
            newBeverageToAdd.pack = pack;
            newBeverageToAdd.price = price;
            newBeverageToAdd.active = active;

            try
            {
                BeverageEntities.Beverages.Add(newBeverageToAdd);
                BeverageEntities.SaveChanges();
                Console.WriteLine("Done.");
            }
            catch(Exception e)
            {
                // remove the new car from the cars collection since we cant save it
                BeverageEntities.Beverages.Remove(newBeverageToAdd);
                Console.WriteLine("Can't add the record. Already have one with that primary key");
            }

        }
        
        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems()
        {
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[wineItemsLength];
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (wineItemsLength > 0)
            {
                //For each item in the collection
                foreach (Beverage beverageItem in BeverageEntities.Beverages)
                {
                    //if the current item is not null.
                    if (beverageItem != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = ("Id: " + beverageItem.id + ", Description: " + beverageItem.name + ", Pack: " + beverageItem.pack + ", Price: " + beverageItem.price.ToString("c") + ", Active: " + beverageItem.active);
                        counter++;

                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            /** //For each WineItem in wineItems
             foreach (Beverages beverageItem in beverage)
             {
                 //If the wineItem is not null
                 if (beverageItem != null)
                 {
                     //if the wineItem Id is the same as the search id
                     if (beverageItem.Id == id)
                     {
                         //Set the return string to the result of the wineItem's ToString method
                         returnString = beverageItem.ToString();
                     }
                 }
             }
             **/

            Beverage foundBeverage = BeverageEntities.Beverages.Find(id);
            Console.WriteLine(Environment.NewLine + "=============== FIND BY ID ===============");
            if (foundBeverage == null)
                Console.WriteLine("That model doesn't exist");
            else
                Console.WriteLine(foundBeverage.id + " " + foundBeverage.name + " " + foundBeverage.pack + " " + foundBeverage.price + " " + foundBeverage.active);

            //Return the returnString
            return returnString;
        }

        public void RemoveByID(string id)
        {
            Beverage carToFindForDelete = BeverageEntities.Beverages.Find(id);

            // remove the car fron the cars collection
            if (carToFindForDelete != null)
            {
                carToFindForDelete = BeverageEntities.Beverages.Find(carToFindForDelete.id);
                //Console.WriteLine(carToFindForDelete.id + " " + carToFindForDelete.name + " " + carToFindForDelete.pack + " " + carToFindForDelete.price + " " + carToFindForDelete.active);
                BeverageEntities.Beverages.Remove(carToFindForDelete);
                BeverageEntities.SaveChanges();
                Console.WriteLine("Just removed a car.");
            }
            else
            {
                Console.WriteLine("That car doesn't exist");
            }
        }

    }
}
