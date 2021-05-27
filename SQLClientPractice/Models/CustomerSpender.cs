using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientPractice.Models
{
     public class CustomerSpender
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public double TotalInvoice { get; set; }
    }
}
