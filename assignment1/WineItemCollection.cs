using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    class WineItemCollection
    {
        private WineItem[] wineItems = new WineItem[4000];      //creates array with 4000 elements to store the wine list from the CSV file
        private CSVProcessor csvProcessor = new CSVProcessor(); //instanciates CSVProcessor class to access and add wine to the file
        private int wineItemsProcessed = 0;                     //creates a number to store the amount of non-null elements in the array

        public WineItem[] WineItems     //WinteItems property
        {
            get { return wineItems; }
            set { wineItems = value; }
        }

        public int WineItemsProcessed   //WineItemsProcessed property
        {
            get { return wineItemsProcessed; }
            set { wineItemsProcessed = value; }
        }

        public void PrintWineList()                             //method to read the entire list and print out every element
        {
            csvProcessor.ImportCSV("../../../datafiles/WineList.csv", wineItems);
            foreach (WineItem wineItem in wineItems)            //loads the entire WineItem array
            {
                if (wineItem != null)                           //only reads a line in the array if an element is not null
                {
                    Console.WriteLine(wineItem.ToString());     //converts the data in one element to a string
                    wineItemsProcessed++;                       //accumulates the amount of each non-null element in the array
                }
            }
        }

        public void SearchWineList()
        {
            Console.WriteLine("Please enter Wine ID:");                             //prompts the user to enter an ID
            string searchID = Console.ReadLine();                                   //creates a string to use as a reference for the search
            bool resultFound = false;                                               //defaults the resultFound boolean to false. this bool tells the program whether or not a matching ID was found
            for (int i = 0; i < wineItemsProcessed; i++)         //begins a loop that runs until a null element is found in order to avoid any exceptions
            {
                if (wineItems[i].ID == searchID)                 //checks each iteration of the for loop to see if the user's ID matches any in the array
                {
                    Console.WriteLine("Result found.");                             //the user is told if a matching result is found        
                    Console.WriteLine(wineItems[i].Description); //the name of the result is printed to the console
                    resultFound = true;                                             //tells the program that a matching result was foundS
                }
            }
            if (resultFound == false) { Console.WriteLine("No results found."); }   //user is told that no results were found if no results were found
        }

        public void AddWineToList()
        {
            string newID = null;
            string newDescription = null;
            string newPack = null;
            Console.WriteLine("Please enter an ID:");
            newID = Console.ReadLine();
            Console.WriteLine("Please enter a description:");
            newDescription = Console.ReadLine();
            Console.WriteLine("Please enter a pack:");
            newPack = Console.ReadLine();
            Console.WriteLine("Adding "  +
                newID + " " + newDescription + " " + newPack + " to the list." + Environment.NewLine +
                "Press 1 to confirm or any other key to cancel.");
            if (Console.ReadLine() == "1")
            {
                File.AppendAllText("../../../datafiles/WineList.csv", newID + "," + newDescription + "," + newPack + Environment.NewLine);
                Console.WriteLine("New wine added.");
            } else {
                Console.WriteLine("New wine cancelled.");
            }
        }
    }
}
