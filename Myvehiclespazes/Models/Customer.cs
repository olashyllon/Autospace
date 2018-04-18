using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myvehiclespazes.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }

    }
}