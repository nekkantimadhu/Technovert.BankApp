using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IAccount
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(string AccId);
        Task<Account> AddAccount(Account account);
        void DeleteAccount(string AccId);
    }
}
