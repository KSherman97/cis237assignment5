//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Int16.MaxValue - 1;  // resets the console bufferhieght to allow the entire file
                                                        // to be read into a single console window
            Console.SetWindowSize(200, 30);             // resizes the window to fit the special output formatting

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            BeverageCollection beverageCollection = new BeverageCollection();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {

                    case 1:
                        //Print Entire List Of Items
                        //Display all of the items
                        try
                        {
                            userInterface.DisplayAllItems(beverageCollection.GetPrintStringsForAllItems());
                            userInterface.DisplayImportSuccess();
                        }
                        catch
                        {
                            userInterface.DisplayImportError();
                        }

                        break;

                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        userInterface.DisplayItemFound(itemInformation);
                        break;

                    case 3:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        decimal newPriceInformation = userInterface.GetNewPriceInformation();
                        bool newActiveInformation = userInterface.GetNewActiveInformation();


                        if (beverageCollection.FindById(newItemInformation[0]) == null)
                        {
                            //beverageCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], newPriceInformation, newActiveInformation);
                            beverageCollection.AddToDatabase(newItemInformation[0], newItemInformation[1], newItemInformation[2], newPriceInformation, newActiveInformation);
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 4:
                        // remove an item
                        string IDToRemove = userInterface.RemoveByID();
                        itemInformation = beverageCollection.FindById(IDToRemove);
                        if (itemInformation != null)
                        {
                            beverageCollection.RemoveByID(IDToRemove);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 5:
                        //update an Item on The List
                        string[] updateBeverageInformation = userInterface.GetUpdateItemInformation();
                        decimal updatePriceInformation = userInterface.GetNewPriceInformation();
                        bool updateActiveInformation = userInterface.GetNewActiveInformation();


                        if (beverageCollection.FindById(updateBeverageInformation[0]) != null)
                        {
                            beverageCollection.updateBeverage(updateBeverageInformation[0], updateBeverageInformation[1], updateBeverageInformation[2], updatePriceInformation, updateActiveInformation);
                            //beverageCollection.updateBeverage("12345", "1", "1", 1, true);

                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
