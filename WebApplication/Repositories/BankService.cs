using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication.Repositories
{
    public class BankService : IBank
    {
        
        private readonly BankContext bankContext;

        public BankService(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }

        public async Task<Bank> GetBank(string BankName)
        {
            return await bankContext.Banks.FirstOrDefaultAsync(b => b.BankName == BankName);
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await bankContext.Banks.ToListAsync();
        }
    }
}
