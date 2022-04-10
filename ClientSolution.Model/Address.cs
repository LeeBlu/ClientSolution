using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientSolution.Model
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public string StreetName { get; set; }
        public string Town  { get; set; }
        public int ProvinceId  { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
