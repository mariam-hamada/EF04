using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank_Management_System.Entites
{
    public class Branch
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Manager Manager { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
