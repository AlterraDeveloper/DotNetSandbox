using System;

namespace DotnetSandbox
{
    public class AccountDto
    {
        public string CustomerName { get; set; }
        public string CurrencySymbol { get; set; }

        public static AccountDto MapFromAccount(Func<Account, PrivateCustomer, AccountDto> mapper, Account account, PrivateCustomer customer)
        {
            return mapper.Invoke(account, customer);
        }

        public override string ToString()
        {
            return $"{CustomerName}, {CurrencySymbol}";
        }

        public static bool MapFromAccount(Func<Account, PrivateCustomer, AccountDto> mapper, Account myUsdAccount)
        {
            throw new NotImplementedException();
        }
    }
}