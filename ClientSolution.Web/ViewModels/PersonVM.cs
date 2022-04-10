using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  ClientSolution.Web.Enums;

namespace ClientSolution.Web.ViewModels
{
    public class PersonVM
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public string Email { get; set; }
        public string PrimaryNumber { get; set; }
        public string SecondaryNumber { get; set; }
    }
}
