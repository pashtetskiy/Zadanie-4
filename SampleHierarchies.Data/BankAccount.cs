using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank.Data
{
    // Bank Account class 
    public class BankAccount
    {
        #region Ctor
        private readonly decimal? _minimumBalance;
        public BankAccount(string? name, decimal? initialBalance)
        {
            try
            {
                if (name is null | name == "") { throw new ArgumentNullException(); }
                Owner = name;
                Number = s_accountNumberSeed.ToString();
                s_accountNumberSeed++;
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
                Console.WriteLine("Your account was succsessfully created");
            }
            catch (ArgumentNullException) { Console.WriteLine("Name is null"); }
        }

        // Ctor
        public BankAccount(string? name, decimal initialBalance, decimal minimumBalance)
        {
            try {
                if (name is null | name == "") { throw new ArgumentNullException(); }
                Number = s_accountNumberSeed.ToString();
                s_accountNumberSeed++;
                Owner = name;
                _minimumBalance = minimumBalance;
                if (initialBalance > 0)
                    MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
                Console.WriteLine("Your account was succsessfully created");
            }
            catch(ArgumentNullException) { Console.WriteLine("Name is null"); }
        }

        private static int? s_accountNumberSeed = 1234567890;
        public string? Number { get; }
        public string? Owner { get; set; }
        public decimal? Balance

        {
            get
            {
                decimal? balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
            set {; }
        }

        private readonly string password;

        private List<Transaction> allTransactions = new List<Transaction>();

        #endregion // Ctor
        // Method for displaying the balance

        #region Public methods
        public void DisplayBalance() 
        {
            Console.WriteLine("Your balance: " + Balance.ToString());
        }

        // Method for depositing money
        public virtual void MakeDeposit(decimal? amount, DateTime date, string note)
        {
            try
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
                }
                var deposit = new Transaction(amount, date, note);
                allTransactions.Add(deposit);
                Console.WriteLine("Your deposit was succsessfully credited");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Amount of deposit must be positive");
            }
            
            
        }

        // Method for withdrawing funds
        public virtual void MakeWithdrawal(decimal? amount, DateTime date, string note)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
                }
                if (Balance - amount < _minimumBalance)
                {
                    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                }
                var withdrawal = new Transaction(-amount, date, note);
                allTransactions.Add(withdrawal);
                Console.WriteLine("Your withdraw was succsessfully credited");

            }
            catch (ArgumentOutOfRangeException) { Console.WriteLine("Amount of withdrawal must be positive"); }
            catch (InvalidOperationException) { Console.WriteLine("Not sufficient funds for this withdrawal"); }
        }

        // Method to get the history of the card
        public string GetAccountHistory()
        {
            try
            {
                if (allTransactions is null | allTransactions.Count == 0) throw new ArgumentNullException(nameof(allTransactions), "Transactions not found");
                var report = new StringBuilder();
                decimal? balance = 0;
                report.AppendLine("Owner\t\tDate\t\tAmount\tBalance\tNote");
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                    report.AppendLine($"{Owner.Substring(0,14)}\t{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
                }
                return report.ToString();
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Transactions not found");
                return null;
            }
            
        }
        public virtual void PerformMonthEndTransactions() { }
        #endregion // Public methods
    }
}
