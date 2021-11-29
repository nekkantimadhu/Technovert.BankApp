using System;
using System.Collections.Generic;
using System.Linq;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class DeleteAccountCLI
    {
        public void DeleteAcc(string BankName)
        {
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();
            string AccId;

            try
            {
                Bank b = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                using (StreamReader reader = new StreamReader(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json"))
                {
                    try
                    {
                        string json = reader.ReadToEnd();
                        reader.Close();
                        var list = JsonConvert.DeserializeObject<List<Bank>>(json);
                        foreach (Bank bankvariable in list)
                        {
                            if (bankvariable.BankName == BankName)
                            {
                                Account account = bankvariable.AccLists.Single(m => m.AccId == AccId);
                                bankvariable.AccLists.Remove(account);
                            }
                        }
                        json = JsonConvert.SerializeObject(list);
                        File.WriteAllText(@"D:\tech\Technovert.BankApp.CLI\Technovert.BankApp.Data\Bank.json", json);
                    }
                    
                    catch (AccountNotAvailableException e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                }

            }
            catch (BankNotAvailableException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}