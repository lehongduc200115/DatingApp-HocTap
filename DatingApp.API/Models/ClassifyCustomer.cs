using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Models
{
    public class ClassifyCustomer
    {
        public int? ID { get; set; }

        public char Group { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
