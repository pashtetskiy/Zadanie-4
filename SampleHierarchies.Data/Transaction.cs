using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data
{
    // Used for deposit and withdraw
    public class Transaction
    {
        #region Ctor
        public decimal? Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        public Transaction(decimal? amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
        #endregion // Ctor;
    }
}
