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
        private string type;
        private decimal amount;
        private DateTime date;

        public Transaction(string type, decimal amount)
        {
            this.type = type;
            this.amount = amount;
            this.date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{date.ToShortDateString()} {type}: {amount} OMR";
        }


    }
}











