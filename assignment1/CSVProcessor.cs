using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    class CSVProcessor
    {
        public bool ImportCSV(string pathToCSVFile, WineItem[] wineItems)
        {
            StreamReader streamReader = null;   //sets up a null StreamReader variable

            try
            {
                string line;                                    //null string to store the contents of the current line in the array

                streamReader = new StreamReader(pathToCSVFile); //locates the CSV file

                int counter = 0;                                //sets up a counter to use for reference in the while loop

                while((line = streamReader.ReadLine()) != null) //runs the loop until a null string is found
                {
                    processLine(line, wineItems, counter++);    //records the contents of each line that is being read
                }

                return true;                                    //returns true if the entire file was succesfully read
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());                //throws an error message to the user if the file was not completely read
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();                       //closes the CSV file when it no longer needs to be read
                }
            }
            return false;                                       //returns false if the file was not correctly read all the way through
        }

        private void processLine(string line, WineItem[] wineItems, int index)  //stores the properties of each wine in the file
        {
            string[] parts = line.Split(',');                                   //tells the program that each property is separated by a comma in the file

            string id = parts[0];                                               //the first property is the ID
            string description = parts[1];                                      //the second property is the description
            string pack = parts[2];                                             //the third property is the pack

            wineItems[index] = new WineItem(id, description, pack);             //sends all three properties to the array
        }
    }
}
