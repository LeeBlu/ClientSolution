using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientSolution.Model;
using  ClientSolution.Web.Enums;

namespace ClientSolution.Web.ViewModels
{
    public class AddressVM
    {
      
        public int AddressId { get; set; }
        public  AddressType addressType { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
       
        public Province province { get; set; }

        public int PersonId { get; set; }
       // public virtual Person Person { get; set; }
    }
}
