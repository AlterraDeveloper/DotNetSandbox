using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DotnetSandbox.Common;

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
            {"8948498", 0}
        };

        public static Account OpenAccount(int customerID, string balanceGroup, int currencyID, decimal startBalance = 0)
        {
            if (!_balanceGroupsCount.ContainsKey(balanceGroup))
                throw new OnlineBankException("Invalid balance group", "180420221922");
            string accountNo;

            try
            {
                ValidateBalanceGroup(balanceGroup);
            }
            catch(OnlineBankException e)
            {
                Logger.LogError(e);
                //TODO: попробуйте запустить код c тремя разными строками ниже и посмотрите внимательно на StackTrace
                // комментируете 2 строки из трех, и запускаете и так с каждой)))
                // throw;
                // throw new Exception(e.Message);
                // throw new Exception(e.Message, e);
            }

            accountNo = $"{balanceGroup}{(++_balanceGroupsCount[balanceGroup]).ToString().PadLeft(11, '0')}";
            Logger.LogInfo($"Создание нового счета {accountNo}");
            return new Account(customerID, accountNo, currencyID, startBalance);
        }

        private static void ValidateBalanceGroup(string balanceGroup)
        {
            if (Regex.IsMatch(balanceGroup, "^\\d{5}$")) return;
            throw new OnlineBankException("Balance group invalid format", "1591986");
        }

        private Account(int customerID, string accountNo, int currencyID, decimal currentBalance)
        {
            CustomerID = customerID;
            AccountNo = accountNo;
            CurrencyID = currencyID;
            Balance = currentBalance;
        }

        public int CustomerID { get; set; }

        public string AccountNo { get; set; }

        public int CurrencyID { get; set; }

        public decimal Balance { get; set; }

        public override string ToString()
        {
            return
                $"Account INfo: CustomerID:{CustomerID}, AccountNo:{AccountNo}, CurrencyID:{CurrencyID}, Balance:{Balance}";
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