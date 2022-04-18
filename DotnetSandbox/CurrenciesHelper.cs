namespace DotnetSandbox
{
    public class CurrenciesHelper
    {
        public static string GetCurrencySymbol(Currencies currency)
        {
            return currency switch
            {
                Currencies.USD => "$",
                Currencies.RUB => "₽",
                _ => "c"
            };
        }
    }
}