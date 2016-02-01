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
            WineItemCollection wineItemCollection = new WineItemCollection();    //instanciate WineItemCollection class

            CSVProcessor csvProcessor = new CSVProcessor();     //instanciate CSVProcessor class

            csvProcessor.ImportCSV("../../../datafiles/WineList.csv", wineItemCollection.WineItems);   //determine path of the CSV file

            UserInterface ui = new UserInterface();     //instanciate UserInterface class

            int choice = ui.FilePrompt();   //integer to determine which number the user chooses when the interface gives its prompt
            while (choice.ToString() != "4")    //runs intil the user chooses 4, which closes the program
            {
                switch (choice) //switch statement to determine what course of action to take, depending on how to user responds to the interface
                {
                    case 1:                                         //case 1 prints the entire wine array
                        wineItemCollection.WineItemsProcessed = 0;  //resets the integer so it won't accumulate with itself if the user prints the wine list more than once
                        wineItemCollection.PrintWineList();         //prints the wine list
                        Console.WriteLine();                        //inputs a blank line
                        choice = ui.FilePrompt();                   //reprompts the user to select an action from the interface
                        break;
                    case 2:                                     //case 2 allows the user to search for a wine by its ID
                        wineItemCollection.SearchWineList();    //method to search the entire wine list
                        Console.WriteLine();                    //inputs a blank line
                        choice = ui.FilePrompt();               //reprompts the user to select an action from the interface
                        break;
                    case 3:
                        wineItemCollection.AddWineToList();
                        Console.WriteLine();
                        choice = ui.FilePrompt();
                        break;
                    default:                                                        //default case that will only run if the user chooses an invalid response to the interface
                        Console.WriteLine("Error. Please select a valid option.");  //the user is told their response is invalid
                        Console.WriteLine();                                        //inputs a blank line
                        choice = ui.FilePrompt();                                   //reprompts the user to select an action from the interface
                        break;
                }
            }
        }
    }
}
