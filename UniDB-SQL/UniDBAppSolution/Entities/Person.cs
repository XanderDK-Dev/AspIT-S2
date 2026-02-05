using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public Addresses Address { get; set; }
        public ContactInformations ContactInformation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
