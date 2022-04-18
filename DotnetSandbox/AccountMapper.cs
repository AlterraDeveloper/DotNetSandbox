namespace DotnetSandbox
{
    public static class AccountMapper
    {
        public static AccountDto Map(Account account, PrivateCustomer customer)
        {
            return new AccountDto
            {
                CustomerName = $"{customer.Surname} {customer.CustomerName}",
                CurrencySymbol = CurrenciesHelper.GetCurrencySymbol((Currencies) account.CurrencyID)
            };
        }
    }
}