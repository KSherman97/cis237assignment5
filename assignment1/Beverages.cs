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
    class Beverages
    {
        //Private Class Level Variables
        private string id;
        private string description;
        private string pack;
        private decimal price;
        private bool active;

        //Public Property to Get the Id
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        //Default Constuctor
        public Beverages() { }

        //3 Parameter Constructor
        public Beverages(string id, string description, string pack, decimal  price, bool active)
        {
            this.id = id;
            this.description = description;
            this.pack = pack;
            this.price = price;
            this.active = active;
        }

        //Override ToString Method to concatenate the fields together.
        public override string ToString()
        {
            return "Id: " + id + ", Description: " + description + ", Pack: " + pack + ", Price: " + price.ToString("c") + ", Active: " + active;
        }


    }
}
