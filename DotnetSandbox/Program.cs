using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

    public enum Currencies
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

      

        static bool boolFunc()
        {
            Console.WriteLine("boolFunc");
            return true;
        }

        static string VisaIntegration() => "I'm Visa card processing";
        static string ElcardIntegration() => "I'm Elcard card processing in IPC";
        static string MasterCardIntegration() => "I'm Master card processing";

        static bool pickForeignAccounts(Account account)
        {
            var foreignCurrencies = new [] {Currencies.EUR, Currencies.USD};
            return foreignCurrencies.Contains((Currencies)account.CurrencyID);
        }

        static void PrintNumber(int maxNumber, int startNumber = 0)
        {
            if (startNumber >= maxNumber) return;
            Console.WriteLine(startNumber);
            PrintNumber(maxNumber, ++startNumber);
        }

        static void Main(string[] args)
        {
            var me = new PrivateCustomer("121358989198", "EVGENII", "kiselev");
            // {
            //     CustomerID = 1,
            //     Surname = "kiselev",
            //     IdentificationNumber = "121358989198",
            //     CustomerName = "EVGENII",
            //     Address = new CustomerAddress
            //     {
            //         CityName = "Bishkek",
            //         CountryName = "KG",
            //         AddressDetails = new CustomerAddressDetails()
            //     }
            // };
            // var dateNow = DateTime.Now;
            // Console.WriteLine(me.Surname);
            // Console.WriteLine(me.CustomerName);
            // Console.WriteLine(dateNow.GetQuarterNumber());
            
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

            try
            {
                var myUsdAccount = Account.OpenAccount(currencyID:(int) Currencies.USD, balanceGroup: "8948498", customerID: me.CustomerID, startBalance: 100);
                var myEurAccount = Account.OpenAccount(me.CustomerID, "10005", (int) Currencies.EUR, 100);
                var myRubAccount = Account.OpenAccount(me.CustomerID, "22111", (int) Currencies.RUB, 100);
                var myKztAccount = Account.OpenAccount(me.CustomerID, "22111", (int) Currencies.KZT, 100);
            }
            catch (OnlineBankException e)
            {
                Console.WriteLine("1 : {0}\n\n", e.Message);
                // Console.WriteLine("2 : {0}\n\n", e.Source);
                Console.WriteLine("3 : {0}\n\n", e.InnerException?.Message);
                Console.WriteLine("4 : {0}\n\n", e.StackTrace);
                // Console.WriteLine("5 : {0}\n\n", e.TargetSite);
                //throw;
            }


            //
            // var currenciesRates = new Dictionary<Currencies, double>
            // {
            //     {Currencies.EUR, 110},
            //     {Currencies.USD, 85},
            //     {Currencies.RUB, 1.5},
            //     {Currencies.KZT, 0.25}
            // };
            //
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

            // int number = 100;
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

            // var numberAsText = "1000";
            //
            // Console.WriteLine(int.TryParse(numberAsText, out var numberAfterParse));
            // Console.WriteLine(numberAfterParse);
            //
            // var validationREsult = CheckIsValidCustomer(me, out var errors);
            // if (!validationREsult)
            // {
            //     foreach (var error in errors)
            //     {
            //         Console.WriteLine(error);
            //     }
            // }
            
            
            // var dict = new Dictionary<int, Account[]>();
            // dict.Add(55, new []{ Account.OpenAccount(55, "10102", 417)});
            // dict.Add(56, new []{ Account.OpenAccount(55, "10102", 417)});
            // dict.Add(57, new []{ Account.OpenAccount(55, "10102", 417)});
            // dict.Add(58, new []{ Account.OpenAccount(55, "10102", 417)});
            //
            // if (dict.TryGetValue(me.CustomerID, out var myAccounts))
            // {
            //     Console.WriteLine(myAccounts);
            // }
            // else
            // {
            //     Console.WriteLine($"Customer with ID {me.CustomerID} not found");
            // }
            
            // me.LinkAccounts(myUsdAccount, myEurAccount, myKztAccount, myRubAccount);
            //
            // me.GetTotalBalance(pickForeignAccounts, currenciesRates);
            
            
            
            //Action<Customer> => function void ...(Customer customer)
            //Predicate<Customer, int> => function bool ...(Customer c, int number)
            //Func<Customer, Account, double> => function double ...(Customer c, Account a)

            // Console.WriteLine("Total balance: {0}", me.GetTotalBalance(pickForeignAccounts, currenciesRates));
            // Console.WriteLine("Total balance: {0}", me.GetTotalBalance(x => 
            //     x.CurrencyID == (int)Currencies.RUB || x.CurrencyID == (int) Currencies.KZT, currenciesRates));
            // Console.WriteLine("Total balance: {0}", me.GetTotalBalance(x => true, currenciesRates));
            //
            // var myUsdaccountDto = AccountDto.MapFromAccount(AccountMapper.Map, myUsdAccount, me);

            // Console.WriteLine(myUsdaccountDto);

            // for (int i = 0; i < 5; i++)
            // {
            //     Console.WriteLine(i);
            // }
            //
            // PrintNumber(5);

            try
            {
                Customer notMe = me;
                var inn = notMe.IdentificationNumber.PadRight(-2);
            }
           
            catch (NullReferenceException e)
            {
                Logger.LogError(e.Message);
            }
            catch (ArgumentException e)
            {
                Logger.LogDebug(e.Message);
            }
            catch(Exception e)
            {
                
            }
            me.Surname = "Ivanov";
            Logger.LogInfo(LogHelper.Dump(me, null));
            
            var reportResult1 = new ReportResult
            {
                IsSuccess = true,
                Files = new List<string>
                {
                    "SwiftApplication.txt",
                    "SwiftApplication2.txt",
                },
            };

            var reportResult2 = new ReportResult
            {
                IsSuccess = false,
                Errors = new List<string>
                {
                    "error 1",
                    "error 2"
                },
            };

            var totalReportResult = reportResult1 + reportResult2;

            Console.WriteLine(totalReportResult.IsSuccess);
            totalReportResult.Files.ForEach(f => Console.WriteLine(f));
            totalReportResult.Errors.ForEach(e => Console.WriteLine(e));


            Console.ReadKey();
        }
    }
};