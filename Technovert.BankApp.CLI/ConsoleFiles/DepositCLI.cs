using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Services;
using Technovert.BankApp.Models.Exceptions;
using Technovert.BankApp.Models;
using Technovert.BankApp.Services.ServiceFiles;

namespace Technovert.BankApp.CLI.ConsoleFiles
{
    internal class DepositCLI
    {
        public void Deposit(string BankName)
        {
            ValidationService validationService = new ValidationService();
            DepositService depositAmount = new DepositService();
            InputsValidation inputsValidation = new InputsValidation();


            string AccId;
            decimal amount = 0;

            try
            {
                Bank bank = validationService.BankAvailability(BankName);
                inputsValidation.EnterAccNum("your");
                AccId = inputsValidation.UserInputString();
                AccId = inputsValidation.CommonValidation(AccId, "AccId");

                Console.WriteLine("Enter your CIF number");
                string cif = System.Console.ReadLine();
                try
                {
                    CurrencyCLI currencyCLI = new CurrencyCLI();
                    currencyCLI.Currency();
                    Account account = validationService.DepositAccountValidity(BankName, AccId, cif);


                    while (true)
                    {
                        try
                        {
                            string option = currencyCLI.CurrencyValidation();
                            inputsValidation.TransactionType("deposit");
                            amount = inputsValidation.DecimalInputsValidation(amount);
                            amount = amount * DataStore.currency[option];
                            break;
                        }
                        catch (AmountFormatException e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                    }
                    try
                    {
                        if (depositAmount.deposit(bank.BankId, account, amount)) 
                            Console.WriteLine("Deposited amount");
                        else 
                            Console.WriteLine("Depositing money failed");
                    }
                    catch (AccountClosedException e)
                    {
                        Console.WriteLine(e.Message);
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