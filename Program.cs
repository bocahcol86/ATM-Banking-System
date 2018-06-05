using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Banking_System
{
    public static class TransactBank
    {
        public class Bank
        {
            public Bank(int accountNum, string accountName, char accountType, double amount)
            {
                AccountNum = accountNum;
                AccountName = accountName;
                AccountType = accountType;
                Amount = amount;
            }

            //all public method to save time
            public int AccountNum
            { get; set; }
            public string AccountName
            { get; set; }
            public char AccountType
            { get; set; }
            public double Amount
            { get; set; }
        }

        public static void StartBank()
        {
            List<Bank> accounts = new List<Bank>();//list of bank objects

            Console.WriteLine("MAIN MENU");
            Console.WriteLine("01. NEW ACCOUNT");
            Console.WriteLine("02. DEPOSIT AMOUNT");
            Console.WriteLine("03. WITHDRAW AMOUNT");
            Console.WriteLine("04. BALANCE ENQUIRY");
            Console.WriteLine("05. ALL ACCOUNT HOLDER LIST");
            Console.WriteLine("06. CLOSE AN ACCOUNT");
            Console.WriteLine("07. MODIFY AN ACCOUNT");
            Console.WriteLine("08. EXIT");

            while (true)
            {
                Console.Write("Select Your Option <1-8>");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1) //create new account
                {
                    Console.WriteLine("----NEW ACCOUNT ENTRY FORM----");
                    Console.Write("Enter The account Number: ");
                    int accountNum = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter The Name of The account Holder: ");
                    string accountName = Console.ReadLine();
                    Console.Write("Enter Type of The account <C/S>: ");
                    char accountType = Convert.ToChar(Console.ReadLine());
                    Console.Write("Enter Initial amount:");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    accounts.Add(new Bank(accountNum, accountName, accountType, amount));
                    Console.WriteLine();
                    continue;
                }
                else if (input == 2) //deposit money from an account
                {
                    Console.WriteLine("----ACCOUNT TRANSACTION FORM----");
                    Console.Write("Enter The accountNo.:");
                    int accountNum = Convert.ToInt32(Console.ReadLine());

                    if (accounts.Any(b => accountNum == b.AccountNum))
                    {
                        var account = accounts.Where(b => b.AccountNum == accountNum);
                        foreach (var item in account)
                        {
                            Console.WriteLine("----ACCOUNT STATUS----");
                            Console.WriteLine("Account No.: " + item.AccountNum);
                            Console.WriteLine("Account Holder Name: " + item.AccountName);
                            Console.WriteLine("Type of Account: " + item.AccountType);
                            Console.WriteLine("Balance amount: " + item.Amount);
                            Console.Write("Enter The amount to DEPOSIT: ");
                            double.TryParse(Console.ReadLine(), out var amount);

                            item.Amount += amount;
                        }

                        Console.Write("Record Updated");
                    }
                    else
                        Console.WriteLine("Account not found.");
                    Console.WriteLine();
                    continue;
                }
                else if (input == 3) //withdraw money from an account
                {
                    Console.WriteLine("----ACCOUNT TRANSACTION FORM----");
                    Console.Write("Enter The accountNo.:");
                    int accountNum = Convert.ToInt32(Console.ReadLine());

                    if (accounts.Any(b => accountNum == b.AccountNum))
                    {
                        var account = accounts.Where(b => b.AccountNum == accountNum);
                        foreach (var item in account)
                        {
                            Console.WriteLine("----ACCOUNT STATUS----");
                            Console.WriteLine("Account No.: " + item.AccountNum);
                            Console.WriteLine("Account Holder Name: " + item.AccountName);
                            Console.WriteLine("Type of Account: " + item.AccountType);
                            Console.WriteLine("Balance amount: " + item.Amount);
                            Console.Write("Enter The amount to WITHDRAW: ");
                            double.TryParse(Console.ReadLine(), out var amount);

                            item.Amount -= amount;
                        }
                        Console.Write("Record Updated");
                    }
                    else
                        Console.WriteLine("Account not found.");
                    Console.WriteLine();
                    continue;
                }
                else if (input == 4) //check balance of an account
                {
                    Console.WriteLine("----BALANCE DETAILS----");
                    Console.Write("Enter The accountNo.:");
                    int accountNum = Convert.ToInt32(Console.ReadLine());

                    if (accounts.Any(b => accountNum == b.AccountNum))
                    {
                        var account = accounts.Where(b => b.AccountNum == accountNum);
                        foreach (var item in account)
                        {
                            Console.WriteLine("----ACCOUNT STATUS----");
                            Console.WriteLine("Account No.: " + item.AccountNum);
                            Console.WriteLine("Account Holder Name: " + item.AccountName);
                            Console.WriteLine("Type of Account: " + item.AccountType);
                            Console.WriteLine("Balance amount: " + item.Amount);
                        }
                    }
                    else
                        Console.WriteLine("Account not found.");
                    Console.WriteLine();
                    continue;
                }
                else if (input == 5) //list all account
                {
                    Console.WriteLine("ACCOUNT HOLDER LIST");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("A/c no.          NAME          Type          Balance");
                    Console.WriteLine("----------------------------------------------------");

                    var num = accounts.GetEnumerator();
                    while (num.MoveNext())
                    {
                        var account = accounts.Where(b => b.Equals(num.Current));
                        foreach (var item in account)
                            Console.WriteLine(item.AccountNum + "                " + item.AccountName + "           "
                                + item.AccountType + "           " + item.Amount);
                    }
                    Console.WriteLine();
                    continue;
                }
                else if (input == 6) //delete account
                {
                    Console.WriteLine("----Delete Record----");
                    Console.Write("Enter The accountNo.:");
                    int accountNum = Convert.ToInt32(Console.ReadLine());

                    if (accounts.Any(b => accountNum == b.AccountNum))
                    {
                        var account = accounts.SingleOrDefault(b => b.AccountNum == accountNum);
                        accounts.Remove(account);
                    }
                    else
                        Console.WriteLine("Account not found.");
                    Console.WriteLine();
                    continue;
                }
                else if (input == 7) //modify account
                {
                    Console.WriteLine("----MODIFY RECORD----");
                    Console.Write("Enter The accountNo.:");
                    int accountNum = Convert.ToInt32(Console.ReadLine());

                    if (accounts.Any(b => accountNum == b.AccountNum))
                    {
                        var account = accounts.Where(b => b.AccountNum == accountNum);
                        foreach (var item in account)
                        {
                            Console.WriteLine("----ACCOUNT STATUS----");
                            Console.WriteLine("Account No.: " + item.AccountNum);
                            Console.WriteLine("Account Holder Name: " + item.AccountName);
                            Console.WriteLine("Type of Account: " + item.AccountType);
                            Console.WriteLine("Balance amount: " + item.Amount);

                            Console.WriteLine("----Enter the New Details----");
                            Console.Write("Account No.: ");
                            item.AccountNum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Modify Account Holder Name: ");
                            item.AccountName = Console.ReadLine();
                            Console.Write("Modify Type of The account <C/S>: ");
                            item.AccountType = Convert.ToChar(Console.ReadLine());
                            Console.Write("Modify Balance amount:");
                            item.Amount = Convert.ToDouble(Console.ReadLine());
                        }

                        Console.WriteLine("Record Updated");
                    }
                    else
                        Console.WriteLine("Account not found.");
                    Console.WriteLine();
                    continue;
                }
                else if (input == 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Your option is invalid. Select Your Option between <1-8>.");
                    Console.WriteLine();
                    continue;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TransactBank.StartBank();

            Console.ReadLine();
        }
    }
}
