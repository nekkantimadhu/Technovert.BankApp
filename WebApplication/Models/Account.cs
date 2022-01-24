using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Account
    {
        public string AccId { get; set; }
        public string BankName { get; set; }
        public string CIF { get; set; }
        
        public decimal Balance { get; set; }
        
        
    }
}
