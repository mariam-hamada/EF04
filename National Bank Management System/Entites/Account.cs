using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank_Management_System.Entites
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; }
        public DateTime OpeningDate { get; set; }

        public int BranchCode { get; set; }

        public Branch Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
