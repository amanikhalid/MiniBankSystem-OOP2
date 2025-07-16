using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Security.Principal;
using System.Transactions;

namespace MiniBankSystem_OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Solve the minibank system with oop part1

            //step 1: determine the main class ex : user or patient or visitor
            //step 2: decide which data will be primitive and which user defined and which is single / list
            // step 3: implement all the user defined classes needed
            // step 4: keep repeating 2,3 till all classes have only primitive
            // step 5: complete all other seperate classes needed
            // step 6: we are now defined all data needed and the next step is to determine the access modifiers / and static
            //step 7: for private data fields implement public methods to set and get them
            //step 8: implemet methods which have logic
            //step 9: implement Main program method with it's logic (instantiate system objects )

            Console.WriteLine(" Welcome to Mini Bank System ");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your National ID: ");
            string id = Console.ReadLine();

            Account userAccount = new Account(name, id);

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. View Transactions");
                Console.WriteLine("5. Exit");

                Console.Write("Option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        decimal dep = Convert.ToDecimal(Console.ReadLine());
                        userAccount.Deposit(dep);
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        decimal wd = Convert.ToDecimal(Console.ReadLine());
                        userAccount.Withdraw(wd);
                        break;

                    case "3":
                        Console.WriteLine($"Current Balance: {userAccount.Balance} OMR");
                        break;

                    case "4":
                        userAccount.ViewTransactionHistory();
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using Mini Bank System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

            }
        }
        class Account
        {
            private string accountHolderName;
            private string nationalId;
            private decimal balance;
            private List<Transaction> transactions;

            // Get and Set
            public string AccountHolderName
            {
                get { return accountHolderName; }
                set { accountHolderName = value; }
            }

            public string NationalId
            {
                get { return nationalId; }
                set { nationalId = value; }
            }

            public decimal Balance
            {
                get { return balance; }
                private set { balance = value; }
            }

            public List<Transaction> Transactions => transactions;

            //Constructor 
            public Account(string name, string id)
            {
                accountHolderName = name;
                nationalId = id;
                balance = 0;
                transactions = new List<Transaction>();
            }
            // Logic Methods
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Amount must be positive.");
                    return;
                }

                balance += amount;
                transactions.Add(new Transaction("Deposit", amount));
                Console.WriteLine($"Deposited: {amount} OMR");

            }
            // Transaction class
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Amount must be positive.");
                    return;
                }
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return;
                }
                balance -= amount;
                transactions.Add(new Transaction("Withdraw", amount));
                Console.WriteLine($"Withdrew: {amount} OMR");

            }

            public void ViewTransactionHistory()
            {
                Console.WriteLine("Transaction History:");
                foreach (var t in transactions)
                {
                    Console.WriteLine(t.ToString());
                }
            }

        }

        class Transaction
        {
            public DateTime Date { get; set; }
            public string Type { get; set; } // Deposit or Withdraw
            public double Amount { get; set; }

            public override string ToString()
            {
                return $"{Date}|{Type}|{Amount}";
            }

            public static Transaction FromString(string line)
            {
                var parts = line.Split('|');
                return new Transaction
                {
                    Date = DateTime.Parse(parts[0]),
                    Type = parts[1],
                    Amount = double.Parse(parts[2])
                };
            }

        }

        class Review
        {
            public string Reviewer { get; set; }
            public DateTime Date { get; set; }
            public int Rating { get; set; }

            public void Priting()
            {
                Console.WriteLine($"{Date}|{Reviewer}|Rating: {Rating}/5");
            }
        }

    }
}











