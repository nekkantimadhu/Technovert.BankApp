﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Technovert.BankApp.Services
{
    public class ValidationService
    {
        public Bank BankAvailability(string BankName)
        {
            using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                bool value = false;
                Bank bank = null;
                foreach (Bank ba in list)
                {
                    if (ba.BankName == BankName)
                    {
                        bank = ba;
                        value = true;
                        break;
                    }
                }
                saveJson(list);
                if (!value)
                {
                    throw new BankNotAvailableException();
                }
                return bank;
                
            }
            /*
                        if (!(DataStore.Banks.Any(m => m.BankName == name)))
                        {
                            throw new BankNotAvailableException();
                            //throw new Exception("Bank not available");
                        }
                        Bank bank = DataStore.Banks.Single(m => m.BankName == name);
                        return bank;*/
        }
        public Account AccountValidity(string BankName, string AccId, string password)
        {
            using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                Account account = null;
                foreach (var ba in list)
                {
                    if (ba.BankName == BankName)
                    {
                        if (ba.AccLists.Any(m => (m.AccId == AccId) && (m.Password == password)))
                        {
                            account = ba.AccLists.Single(m => (m.AccId == AccId) && (m.Password == password));
                            break;
                        }

                    }
                }
                saveJson(list);
                if (account == null) throw new AccountNotAvailableException();
                return account;
                
            }

            /*Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId) && (m.Password == password))))
            {
                //throw new Exception("Account not available");
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId) && (m.Password == password));
            return account;*/
        }
        public Account UpdateorDeleteAccountValidity(string BankName, string AccId)
        {
            using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                Account account = null;
                foreach (var bankvar in list)
                {
                    if (bankvar.BankName == BankName)
                    {
                        if (bankvar.AccLists.Any(m => (m.AccId == AccId)))
                        {
                            account = bankvar.AccLists.Single(m => (m.AccId == AccId));
                            break;
                        }

                    }
                }
                saveJson(list);
                if (account == null) throw new AccountNotAvailableException();
                return account;
            }
            /*Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
        if (!(bank.AccLists.Any(m => (m.AccId == AccId))))
        {
            //throw new Exception("Account not available");
            throw new AccountNotAvailableException();
        }
        Account account = bank.AccLists.Single(m => (m.AccId == AccId));
        return account;*/
        }
        public Account DepositAccountValidity(string BankName, string AccId, string cif)
        {
            using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                Account account = null;
                foreach (var bankvar in list)
                {
                    if (bankvar.BankName == BankName)
                    {
                        if (bankvar.AccLists.Any(m => (m.AccId == AccId) && (m.CIF == cif)))
                        {
                            account = bankvar.AccLists.Single(m => (m.AccId == AccId) && (m.CIF == cif));
                            break;
                        }

                    }
                }
                saveJson(list);
                if (account == null) throw new AccountNotAvailableException();
                return account;
            }
            /*Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId) && (m.CIF == cif))))
            {
                //throw new Exception("Account not available");
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId) && (m.CIF == cif));
            return account;*/
        }
        public Account DesAccountValidity(string BankName, string AccId)
        {
            using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
            {
                string json = reader.ReadToEnd();
                reader.Close();
                var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                Account account = null;
                foreach (var bankvar in list)
                {
                    if (bankvar.BankName == BankName)
                    {
                        if (bankvar.AccLists.Any(m => (m.AccId == AccId)))
                        {
                            account = bankvar.AccLists.Single(m => (m.AccId == AccId));
                            break;
                        }

                    }
                }
                saveJson(list);
                if (account == null) throw new AccountNotAvailableException();
                return account;
            }
            /*Bank bank = DataStore.Banks.Single(m => m.BankName == BankName);
            if (!(bank.AccLists.Any(m => (m.AccId == AccId))))
            {
                throw new AccountNotAvailableException();
            }
            Account account = bank.AccLists.Single(m => (m.AccId == AccId));
            return account;*/
        }
        public void UpdateMobile(string Mobile, string BankName, string AccId)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
                {
                    string json = reader.ReadToEnd();
                    reader.Close();
                    var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                    foreach (var bankvar in list)
                    {
                        if (bankvar.BankName == BankName)
                        {
                            Account ac = bankvar.AccLists.SingleOrDefault(m => m.AccId == AccId);
                            ac.Mobile = Mobile;
                        }
                    }
                    saveJson(list);
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }

        }
        public void UpdatePassword(string password, string BankName, string AccId)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
                {
                    string json = reader.ReadToEnd();
                    reader.Close();
                    var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                    foreach (var bankvar in list)
                    {
                        if (bankvar.BankName == BankName)
                        {
                            Account account = bankvar.AccLists.SingleOrDefault(m => m.AccId == AccId);
                            account.Password = password;
                        }
                    }
                    saveJson(list);
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }

        }
        public void UpdateGender(string Gender, string BankName, string AccId)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
                {
                    string json = reader.ReadToEnd();
                    reader.Close();
                    var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                    foreach (var bankvariable in list)
                    {
                        if (bankvariable.BankName == BankName)
                        {
                            Account account = bankvariable.AccLists.SingleOrDefault(m => m.AccId == AccId);
                            account.Gender = Gender;
                        }
                    }
                    saveJson(list);
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }

        }

        public void saveJson(List<Bank> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json", json);
        }
    }
}