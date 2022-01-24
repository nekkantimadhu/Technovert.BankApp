using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Transaction
    {
        public string TransId { get; set; }
        public string BankId { get; set; }
        public string UserId { get; set; }

        public string DestinationId { get; set; }
        public string DestinationBankId { get; set; }


        public decimal Amount { get; set; }

        public DateTime On { get; set; }

        public decimal Balance { get; set; }
    }
}
