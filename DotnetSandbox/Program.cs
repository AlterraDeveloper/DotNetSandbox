using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetSandbox
{
    enum CustomerType
    {
        PrivateCustomer,
        LegalCustomer
    }

    enum CardType : byte
    {
        Visa,
        Mir,
        Elcart,
        MasterCard
    }

    enum Currencies
    {
        RUB = 643,
        KZT = 398,
        USD = 840,
        EUR = 978
    }

    class Program
    {
        static string getCurrencySymbol(Currencies currency)
        {
            return currency switch
            {
                Currencies.USD => "$",
                Currencies.RUB => "₽",
                _ => "c"
            };
        }

        static bool boolFunc()
        {
            Console.WriteLine("boolFunc");
            return true;
        }

        static string VisaIntegration() => "I'm Visa card processing";
        static string ElcardIntegration() => "I'm Elcard card processing in IPC";
        static string MasterCardIntegration() => "I'm Master card processing";

        static void Main(string[] args)
        {
            
            var me = new PrivateCustomer
            {
                CustomerID = 1,
                CustomerName = "Eugene",
                Surname = "Kiselev"
            };
            var meToo = new PrivateCustomer("00101199200789", "Ergeshov Ernis");
            
            var meToo2 = new LegalCustomer();

            Console.WriteLine(meToo.IdentificationNumber ?? "NONE");
            Console.WriteLine(meToo2.IdentificationNumber ?? "NONE");
            
            
            // var account = new Account();
            // var myUsdAccount = new Account(me.CustomerID, "5050550055050", (int) Currencies.USD);
            // var myEurAccount = new Account(me.CustomerID, "5050550055051", (int) Currencies.EUR, 200);

            var myUsdAccount = Account.OpenAccount(me.CustomerID, "10005", (int) Currencies.USD);
            var myEurAccount = Account.OpenAccount(me.CustomerID, "10005", (int) Currencies.EUR);
            var myRubAccount = Account.OpenAccount(me.CustomerID, "22111", (int) Currencies.RUB);
            var myKztAccount = Account.OpenAccount(me.CustomerID, "22111", (int) Currencies.KZT);
            
            Console.WriteLine(myUsdAccount);
            Console.WriteLine(myEurAccount);
            Console.WriteLine(myRubAccount);
            Console.WriteLine(myKztAccount);

            Console.ReadKey();
        }
    }
};