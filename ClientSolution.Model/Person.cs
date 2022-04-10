using System;
using System.Collections.Generic;
using System.Text;

namespace ClientSolution.Model
{
   public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
         public int GenderId { get; set; }
        public string  Email { get; set; }
        public string PrimaryNumber { get; set; }
        public string  SecondaryNumber { get; set; }
    }
}
