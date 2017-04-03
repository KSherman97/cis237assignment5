//Author: Kyle Sherman
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class CSVProcessor
    {
        //Declare a variable to flag whether the CSV has been imported.
        bool hasBeenImported;

        //Constructor
        public CSVProcessor()
        {
            this.hasBeenImported = false;
        }

        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Public method to Import the CSV
        public bool ImportCSV(IWineCollection wineItems, string pathToCSVFile)
        {
            //Declare the streamreader
            StreamReader streamReader = null;

            //If it hasn't already been imported
            if (!hasBeenImported)
            {
                try
                {
                    //declare a string for the line
                    string line;

                    //Declare and instanciage a new StreamReader class
                    streamReader = new StreamReader(pathToCSVFile);

                    //While still reading a line from the file
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //Process the line
                        this.processLine(line, wineItems);
                    }
                    //Set hasBeenImported to true now that it is imported
                    hasBeenImported = true;

                    //Return true to represent success
                    return true;
                }
                catch (Exception e)
                {
                    //Output the Error that occured. This is the only output that is NOT being done in the UI class
                    Console.WriteLine(e.ToString());
                    Console.WriteLine();
                    Console.WriteLine(e.StackTrace);

                    //Return false to signify that it failed
                    return false;
                }
                finally
                {
                    //If the stream reader was instanciated, make sure it is closed before exiting.
                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }
                }
                
            }
            //It has already been imported. No need to do it again.
            else
            {
                //return false
                return false;
            }
        }

        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        private void processLine(string line, IWineCollection wineItemCollection)
        {
            //declare array of parts that will contian the results of splitting the read in string
            string[] parts = line.Split(',');

            //Assign each part to a variable
            string id = parts[0];
            string description = parts[1];
            string pack = parts[2];

            //Add a new wine item into the collection with the properties of what was read in.
            wineItemCollection.AddNewItem(id, description, pack);
        }
    }
}
