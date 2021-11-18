﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using System.IO;
using Newtonsoft.Json;

namespace Technovert.BankApp.Services
{
    public class DepositService
    {
        public bool Deposit(string BankId, Account account, decimal amt)
        {

            StatusService status = new StatusService();
            AccountStatus stat = status.Status(account);
            if (stat == AccountStatus.Closed)
            {
                throw new AccountClosedException("Your Account Is Closed");
            }

            account.Balance = account.Balance + amt;
            account.UpdatedOn = DateTime.Now;
            account.UpdatedBy = account.AccId;

            string transid = "TXN" + BankId + account.AccId + DateTime.Now;
            account.TransactionHistory.Add(new Transaction { BankId = BankId, TransId = transid, UserId = account.AccId, Amount = amt, On = DateTime.Now, Type = TransactionType.Deposit, Balance = account.Balance });

            string json = JsonConvert.SerializeObject(DataStore.Banks);
            File.WriteAllText(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Services\Bank.json", json);
            return true;
        }
    }
}