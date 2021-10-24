﻿using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Services.ServiceFiles;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;

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
                try
                {
                     Account account = validationService.UpdateorDeleteAccountValidity(BankName, AccId);
                     b.AccLists.Remove(account);
                }
                catch (AccNotAvailableException e)
                {
                     System.Console.WriteLine(e.Message);
                }

            }
            catch (BankNotAvailableException e)
            {
                    System.Console.WriteLine(e.Message);
            }
        }
    }
}
