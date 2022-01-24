using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class AccountService : IAccount
    {
        private readonly BankContext bankContext;

        public AccountService(BankContext appDbContext)
        {
            this.bankContext = appDbContext;
        }
        public async Task<Account> AddAccount(Account account)
        {
            var result = await bankContext.Accounts.AddAsync(account);
            await bankContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Account> GetAccount(string AccId)
        {
            return await bankContext.Accounts.FirstOrDefaultAsync(
                a => a.AccId == AccId);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await bankContext.Accounts.ToListAsync();
        }
        public async void DeleteAccount(string accountNumber)
        {
            var result = await bankContext.Accounts.FirstOrDefaultAsync(
                a => a.AccId == accountNumber);
            if (result != null)
            {
                bankContext.Accounts.Remove(result);
                await bankContext.SaveChangesAsync();
            }
        }

       
    }
}
