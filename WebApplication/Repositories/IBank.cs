using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IBank
    {
        Task<IEnumerable<Bank>> GetBanks();
        Task<Bank> GetBank(string BankName);
    }
}
