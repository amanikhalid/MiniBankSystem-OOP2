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
        public int Number { get; }
        public string Name { get; }
        public double Balance { get; private set; }
        public string Password { get; }
        public List<Transaction> Transactions { get; }
        public int AccountNumber { get; private set; }

        public string NationalId { get; private set; }

        public string UserType { get; set; }
        public bool IsLocked { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string HashedPassword;

        public Account(int number, string name, double balance, string hashedPassword)
        {
            AccountNumber = number;
            Name = name;
            Balance = balance;
            HashedPassword = hashedPassword;
            NationalId = "";
            UserType = "customer";
            Phone = "";
            Address = "";
            IsLocked = false;
            Transactions = new List<Transaction>();

        }

    }
}








