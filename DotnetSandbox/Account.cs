using System.Collections.Generic;

namespace DotnetSandbox
{
    /// <summary>
    /// Модель счета
    /// </summary>
    public class Account
    {
        private static Dictionary<string, int> _balanceGroupsCount = new Dictionary<string, int>
        {
            {"10005", 0},
            {"22111", 0},
            {"40333", 0},
        };

        public static Account OpenAccount(int customerID, string balanceGroup, int currencyID)
        {
            if (!_balanceGroupsCount.ContainsKey(balanceGroup)) return null;
            string accountNo;

            accountNo = $"{balanceGroup}{(++_balanceGroupsCount[balanceGroup]).ToString().PadLeft(11, '0')}";
            
            return new Account(customerID, accountNo, currencyID, 0);
        }
        
        private Account(int customerID, string accountNo, int currencyID, decimal currentBalance)
        {
            CustomerID = customerID;
            AccountNo = accountNo;
            CurrencyID = currencyID;
            Balance = currentBalance;
        }

        public int CustomerID { get; private set; }

        public string AccountNo { get; set; }

        public int CurrencyID { get; set; }

        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $"Account INfo: CustomerID:{CustomerID}, AccountNo:{AccountNo}, CurrencyID:{CurrencyID}, Balance:{Balance}";
        }

        public decimal BalanceN { get; set; }

        public void MakeIncome(decimal amount)
        {
            this.BalanceN += amount;
        }
        
        public void MakeWithdrawal(decimal amount)
        {
            this.BalanceN -= amount;
        }
    }
}