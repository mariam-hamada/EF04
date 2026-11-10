using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank_Management_System.Entites
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string CustomerType { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
