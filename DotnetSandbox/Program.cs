using System;
using System.Collections.Generic;
using DotnetSandbox.Common;

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
        private static bool _isInDebug = true;

        private static void PrintInfo()
        {
            if (_isInDebug)
            {
                Console.WriteLine("DEBUG MODE!!!");
                return;
            }

            Console.WriteLine("RELEASE!!!");
        }

        private static void ChangeMode()
        {
            _isInDebug = !_isInDebug;
        }

        private static void ModifyPrimitive(ref int number)
        {
            number += 10;
        }

        private static void ModifyReference(object obj)
        {
            var i = (int) obj;
            return;
            i += 10;
            obj = i;
        }

        private static void AnnulateAccount(ref Account account)
        {
            // account.Balance = 0;
            // account.BalanceN = 0;
            account = Account.OpenAccount(account.CustomerID, "10005", account.CurrencyID);
        }


        private static bool CheckIsValidCustomer(Customer customer, out List<string> errors)
        {
            errors = new List<string>();
            if (customer is PrivateCustomer privateCustomer)
            {
                if(string.IsNullOrEmpty(privateCustomer.Address?.ToString())) errors.Add("Address is required");
                if(string.IsNullOrEmpty(privateCustomer.Surname)) errors.Add($"{nameof(privateCustomer.Surname)} is required");
                if(string.IsNullOrEmpty(privateCustomer.CustomerName)) errors.Add($"{nameof(privateCustomer.CustomerName)} is required");
            }

            if (customer is LegalCustomer legalCustomer)
            {
                if(string.IsNullOrEmpty(legalCustomer.SocialFondCode)) errors.Add("Social fond code is required");
            }

            return errors.Count == 0;
        }

        private static string GetCurrencySymbol(Currencies currency)
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
                Surname = "Kiselev"
            };
            //
            // var meToo = new PrivateCustomer("00101199200789", "Ergeshov Ernis");
            // var meToo2 = new PrivateCustomer("00101199200789", "Kiselev Evgenii");
            //
            // Console.WriteLine("Equals test: {0}", meToo.Equals(meToo2));
            //
            // Console.WriteLine(meToo.GetHashCode());
            // Console.WriteLine(meToo2.GetHashCode());

            // var customerSet = new HashSet<Customer>();
            // customerSet.Add(meToo);
            // customerSet.Add(meToo2);


            // var meToo2 = new LegalCustomer();

            // Console.WriteLine(meToo.IdentificationNumber ?? "NONE");
            // Console.WriteLine(meToo2.IdentificationNumber ?? "NONE");


            // var account = new Account();
            // var myUsdAccount = new Account(me.CustomerID, "5050550055050", (int) Currencies.USD);
            // var myEurAccount = new Account(me.CustomerID, "5050550055051", (int) Currencies.EUR, 200);

            var myUsdAccount = Account.OpenAccount(currencyID:(int) Currencies.USD, balanceGroup: "10005", customerID: me.CustomerID);
            // var myEurAccount = Account.OpenAccount(me.CustomerID, "10005", (int) Currencies.EUR);
            // var myRubAccount = Account.OpenAccount(me.CustomerID, "22111", (int) Currencies.RUB);
            // var myKztAccount = Account.OpenAccount(me.CustomerID, "22111", (int) Currencies.KZT);

            // Console.WriteLine(myUsdAccount);
            // Console.WriteLine(myEurAccount);
            // Console.WriteLine(myRubAccount);
            // Console.WriteLine(myKztAccount);


            // Console.WriteLine(RegexSandbox.ValidateInn("50101199155555") ? "Inn Correct" : "Inn ERROR");
            // Console.WriteLine(RegexSandbox.SearchMe("kisilev").Value);
            // Console.WriteLine(RegexSandbox.ReplacementSymbols(
            //     "Здравствуйте, Я клиент с ID = [CustomerID], прошу Вас разблокировать мой счет [AccountNo]"));
            //
            // var securityValidator = new SimpleSecurityValidator();
            // var customerSecurityProvider = new CustomerCollectionSecurityProvider(securityValidator);
            //
            // var customerSet = new HashSet<Customer>();
            // if (customerSecurityProvider.IsAddAllowed())
            // {
            //     customerSet.Add(meToo);
            //     customerSet.Add(meToo2);
            // }
            //
            // if (customerSecurityProvider.IsViewAllowed())
            // {
            //     foreach (var customer in customerSet)
            //     {
            //         Console.WriteLine(customer);
            //     }
            // }
            //
            // Console.WriteLine($"Set count: {customerSet.Count}");

            // ChangeMode();
            // PrintInfo();
            //
            // ChangeMode();
            // PrintInfo();

            int number = 100;
            // object number2 = 100;
            // ModifyPrimitive(ref number);
            // ModifyReference(number2);
            //
            // Console.WriteLine(myUsdAccount);
            // AnnulateAccount(ref myUsdAccount);
            // Console.WriteLine(myUsdAccount);
            //
            // Console.WriteLine(number);
            //
            // var gnsWepApiHelper = ServiceHelper.Build()
            //     .WithProtocol(NetworkProtocol.HTTPS)
            //     .WithBaseAddress("www.gns.kg/api")
            //     .WithEncryption("sha256");
            //
            // var socFond = ServiceHelper.Build()
            //     .WithProtocol(NetworkProtocol.HTTP)
            //     .WithBaseAddress("www.socfond.kg/public/api");

            var numberAsText = "1000";
            
            Console.WriteLine(int.TryParse(numberAsText, out var numberAfterParse));
            Console.WriteLine(numberAfterParse);

            var validationREsult = CheckIsValidCustomer(me, out var errors);
            if (!validationREsult)
            {
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }

            Console.ReadKey();
        }
    }
};