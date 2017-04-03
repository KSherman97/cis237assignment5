//Author: Kyle Sherman
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
        UserInterface userInterface = new UserInterface();

        //Private Variables
        Beverages[] beverage;
        int wineItemsLength;

        BeverageKShermanEntities BeverageEntities = new BeverageKShermanEntities();
        //Console.WriteLine("Print the list");

        //Constuctor. Must pass the size of the collection.

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

        // add to database
        public void AddToDatabase(string id, string description, string pack, decimal price, bool active)
        {
            Beverage newBeverageToAdd = new Beverage();
            newBeverageToAdd.id = id;               // assigns the user input to the id value
            newBeverageToAdd.name = description;    // assigns the user input to the name value
            newBeverageToAdd.pack = pack;           // assigns the user input to the pack value
            newBeverageToAdd.price = price;         // assigns the user input to the price value
            newBeverageToAdd.active = active;       // assigns the user input to the active value

            // try catch, fails if the beverage is null 
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
        public string GetPrintStringsForAllItems()
        {
            string output = string.Empty;

            // foreach loops through each item in the beverage.Entities from the database
            foreach (Beverage beverageItem in BeverageEntities.Beverages)
            {
                output += "Id: " + beverageItem.id + ", Description: " + beverageItem.name + ", Pack: " + beverageItem.pack + ", Price: " + beverageItem.price.ToString("c") + ", Active: " + beverageItem.active + Environment.NewLine;
            }

            return output;

        }
        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            Beverage foundBeverage = BeverageEntities.Beverages.Find(id);
            if (foundBeverage == null)
                userInterface.DisplayItemFoundError();
            else
                Console.WriteLine("Id: " + foundBeverage.id + ", Description: " + foundBeverage.name + ", Pack: " + foundBeverage.pack + ", Price: " + foundBeverage.price.ToString("c") + ", Active: " + foundBeverage.active + Environment.NewLine);

            //Return the returnString
            return returnString;
        }

        public void RemoveByID(string id)
        {
            Beverage carToFindForDelete = BeverageEntities.Beverages.Find(id);

            // remove the car fron the cars collection
            // then save the changes made to the database
                carToFindForDelete = BeverageEntities.Beverages.Find(carToFindForDelete.id);
                BeverageEntities.Beverages.Remove(carToFindForDelete);
                BeverageEntities.SaveChanges();
        }

        public void updateBeverage(string id, string description, string pack, decimal price, bool active)
        {
            Beverage beverageToFindForUpdate = BeverageEntities.Beverages.Find(id);

            // update some of the properties of the car we found
            // all of them if we don't want to
            if (beverageToFindForUpdate != null)
            {
                beverageToFindForUpdate = BeverageEntities.Beverages.Find(beverageToFindForUpdate.id);
                beverageToFindForUpdate.name = description;
                beverageToFindForUpdate.pack = pack;
                beverageToFindForUpdate.price = price;
                beverageToFindForUpdate.active = active;

                // save the new updates to the database. Since when we pulled out the one 
                // to update, all we were really doing was getting a reference to the one in
                // the collection we wanted to update, there is no need ot 'put' the car
                // back into the cars collection. it is still there.
                // all we have to do is save the changes.
                BeverageEntities.SaveChanges();
            }
            else
            {
                userInterface.DisplayItemFoundError();
            }

        }

    }
}
