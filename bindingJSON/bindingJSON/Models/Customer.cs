using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bindingJSON.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; } // squirrels aren't required tell us their age        
        public char Gender { get; set; }
        public string Hobby { get; set; }
    }
}