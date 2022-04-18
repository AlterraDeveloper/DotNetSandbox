using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetSandbox
{
    public abstract partial class Customer
    {
        protected virtual bool ValidateIdentificationNumber(string identificationNumber)
        {
            return identificationNumber.Length == InnLength;
        }

        public void LinkAccounts(params Account[] accounts)
        {
            Accounts = accounts.Where(CheckOwner).ToList();
        }

        private bool CheckOwner(Account accountToCheck)
        {
            return accountToCheck.CustomerID == CustomerID;
        }
        
        public double GetTotalBalance(Func<Account, bool> filterAccounts, Dictionary<Currencies, double> rates)
        {
            return Accounts.Where(filterAccounts)
                .Select(x => rates[(Currencies) x.CurrencyID] * (double) x.Balance)
                .Sum();
        }

        public override bool Equals(object obj)
        {
            var anotherCustomer = obj as Customer;
            if (anotherCustomer is null) return false;
            return this.IdentificationNumber == anotherCustomer.IdentificationNumber;
        }

        public override int GetHashCode()
        {
            return IdentificationNumber.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{nameof(CustomerID)} = {CustomerID}\n");
            sb.Append($"{nameof(IdentificationNumber)} = {IdentificationNumber}\n");
            return sb.ToString();
        }
    }
}