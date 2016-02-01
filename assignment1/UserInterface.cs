using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        public int FilePrompt()
        {
            this.printFilePrompt(); //the user is displayed what options they can do with the wine list

            string promptResponse = Console.ReadLine(); //program records the user's response to the promptResponse string
            while (promptResponse != "1" && promptResponse != "2" && promptResponse != "3" && promptResponse != "4")    //runs while the user continues to provide an invalid response
            {
                Console.WriteLine("Error. Please select a valid number." + Environment.NewLine);                        //user is told that their response was invalid
                this.printFilePrompt();                                                                                 //user is listed the options once again
                promptResponse = Console.ReadLine();                                                                    //program records the user's response again
            }

            return Int32.Parse(promptResponse); //returns any valid response from the user
        }

        private void printFilePrompt()                          //method to display the user interface and their possible courses of action
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print Wine List");
            Console.WriteLine("2. Search for Wine");
            Console.WriteLine("3. Add Wine to List");
            Console.WriteLine("4. Exit");
        }
    }
}
