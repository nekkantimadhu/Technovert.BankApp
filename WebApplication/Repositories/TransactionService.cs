using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Repositories
{
    public class TransactionService : ITransaction
    {
        private readonly BankContext bankContext;

        public TransactionService(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }
        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            var result = await bankContext.Transactions.AddAsync(transaction);
            await bankContext.SaveChangesAsync();
            return result.Entity;

        }

        public async  Task<Transaction> GetTransaction(string TransactionID)
        {
            return await bankContext.Transactions.FirstOrDefaultAsync(e => e.TransId == TransactionID);
        }

        public async  Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await bankContext.Transactions.ToListAsync();
        }
    }
}
