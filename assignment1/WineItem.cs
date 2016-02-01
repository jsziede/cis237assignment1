using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItem
    {
        private string id;          //string to store the ID of an individual wine
        private string description; //string to store the description of an individual wine
        private string pack;        //string to store the pack of an individual wine

        public string ID                    //ID property
        {
            get { return id; }
            set { id = value; }
        }

        public string Description           //Description property
        {
            get { return description; }
            set { description = value; }
        }

        public string Pack                  //Pack property    
        {
            get { return pack; }
            set { pack = value; }
        }

        public override string ToString()                               //override method to print out the three properties when using ToString
        {
            return this.id + " " + this.description + " " + this.pack;
        }

        public WineItem(string id, string description, string pack) //constructor with three parameters
        {
            this.id = id;
            this.description = description;
            this.pack = pack;
        }

        public WineItem()   //blank constructor
        {
            
        }
    }
}
