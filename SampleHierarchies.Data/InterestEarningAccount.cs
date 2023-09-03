using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data
{
    public class InterestEarningAccount : BankAccount
    {
        #region Public Methods
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance) { }
        public override void PerformMonthEndTransactions() // Add Interest 
        {
            if (Balance > 500m)
            {
                decimal? interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
        #endregion // Public Methods
    }
}
