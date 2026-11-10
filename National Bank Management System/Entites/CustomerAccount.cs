using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank_Management_System.Entites
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }

        public DateTime OwnershipStartDate { get; set; }
        public string OwnershipType { get; set; }
        public string AccountStatus { get; set; }

        public Customer Customer { get; set; }
        public Account Account { get; set; }
    }
}
