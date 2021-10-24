﻿using System;
using System.Collections.Generic;
using System.Text;
using Technovert.BankApp.Services.ServiceFiles;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class UpdateAccountCLI
    {
        public void UpdateAcc(string BankName)
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
                AccId = inputsValidation.CommonValidation(AccId, "AccId");

                try
                {
                    Account account = validationService.UpdateorDeleteAccountValidity(BankName, AccId);
                    Console.WriteLine("Choose option to update 1.Mobile\n 2.Password\n 3.Gender");
                    int option = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter updated value");
                    if (option == 1)
                    {
                        account.Mobile = Console.ReadLine();
                    }
                    else if (option == 2)
                    {
                        account.Password = Console.ReadLine();
                    }
                    else
                    {
                        account.Gender = Console.ReadLine();
                    }
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
