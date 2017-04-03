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
    class BeverageCollection : IWineCollection
    {
        //Private Variables
        BeverageItem[] wineItems;
        int wineItemsLength;

        //Constuctor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            wineItems = new BeverageItem[size];
            wineItemsLength = 0;
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack)
        {
            //Add a new WineItem to the collection. Increase the Length variable.
            wineItems[wineItemsLength] = new BeverageItem(id, description, pack);
            wineItemsLength++;
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
                foreach (BeverageItem wineItem in wineItems)
                {
                    //if the current item is not null.
                    if (wineItem != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = wineItem.ToString();
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

            //For each WineItem in wineItems
            foreach (BeverageItem wineItem in wineItems)
            {
                //If the wineItem is not null
                if (wineItem != null)
                {
                    //if the wineItem Id is the same as the search id
                    if (wineItem.Id == id)
                    {
                        //Set the return string to the result of the wineItem's ToString method
                        returnString = wineItem.ToString();
                    }
                }
            }
            //Return the returnString
            return returnString;
        }

    }
}
