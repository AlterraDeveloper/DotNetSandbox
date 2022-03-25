using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotnetSandbox
{
    public class Lesson_1_5
    {
        public static void Method()
        {
            // byte _byte = 0;
            // short _short = 45;
            // int _int = 567;
            // long _long = 5648;
            // uint _unit = 5;
            // int age = 25;
            // Int32 age32 = 32;
            // decimal _money = 25;
            //
            // float _float = 0.25f;
            // double _double = 0.00000000000049789;
            //
            // dynamic _var = 5;

            // Console.WriteLine(_var);
            //
            // _var = true;
            //
            // Console.WriteLine(_var);
            //
            // object obj = null;

            // string text = $"I am {obj.GetHashCode()} y.o.";
            // string pathToMyProject = @"C:\Code\DotnetSandbox";
            //
            // Console.OutputEncoding = Encoding.ASCII;
            // Console.WriteLine((int)ch);
            //

            //nullable variables

            // Nullable<int> _anotherCardHolderID = null;
            // int? cardHolderID = null;
            //
            // int cardHolderAge = 35;
            //
            // byte cardHolderAgeInt = (byte) cardHolderAge;
            //
            // Console.WriteLine(cardHolderAgeInt);

            // var isResident = true;
            //
            // var isResidentDb = Convert.ToInt32(isResident);
            // Console.WriteLine(isResidentDb);

            // var isResidentText = "true";
            // var isParseSuccess = bool.TryParse(isResidentText, out var isResident);
            //
            // Console.WriteLine(isResident);
            // Console.WriteLine(isParseSuccess);

            //Boxing / Unboxing

            // var _int = 5;
            // Int32 refInt = _int; 
            //
            // _int = refInt; //Unboxing
            //
            // object obj = _int; //Boxing
            // Console.WriteLine(obj);
            //
            // obj = true;
            // Console.WriteLine(obj);

            //унарные

            // var IsNonResident = !isResident;
            // var minusInt = -_int;

            // бинарные

            // var div = 12 % 5;
            //
            // var boolResult = true;
            //
            // var andOper = false && boolFunc();
            // var orOper = true | boolFunc();

            // тернарный оператор

            // bool? customerSex = true;
            //
            // string customerSexText;
            //     //!customerSex.HasValue ? "Юр.лицо" : (bool)customerSex ? "Жен." : "Муж.";
            // if (customerSex.HasValue)
            // {
            //     customerSexText = (bool) customerSex ? "Жен." : "Муж.";
            // }
            // else
            // {
            //     customerSexText = "Юр.лицо";
            // }

            // Console.WriteLine(customerSexText);


            // var isResident = false;
            //
            // Console.WriteLine(isResident ? "Резидент" : "Нерезидент");
            //
            // var customerID = 0;
            //
            // if (customerID > 0)
            // {
            //     Console.WriteLine($"Client with ID {customerID} was found...");
            // }
            //
            // isResident = false;
            //
            //
            // var customerINN = "";
            // var swiftCurrencyID = 643;
            // CustomerType customerType = CustomerType.LegalCustomer;
            // var customerName = "";
            // var companyNameRu = "ОсОО ФинансСофт";
            // var companyNameEng = "FinanceSoft LLC";
            //
            // if (!(swiftCurrencyID == 643 || swiftCurrencyID == 378))
            // {
            //     Console.WriteLine(customerType == CustomerType.PrivateCustomer ? customerName : 
            //         string.IsNullOrEmpty(companyNameEng) ? companyNameRu : companyNameEng);
            // }
            //
            //
            // var cardType = CardType.Elcart;
            // var cardTypeFromDb = 3;
            //
            // string integration2;
            // //switch statement
            // switch (cardType)
            // {
            //     case CardType.Visa:
            //     case CardType.Elcart:
            //         if (!(isResident && customerType == CustomerType.PrivateCustomer)) break;
            //         integration2 = VisaIntegration();
            //         break;
            //     case CardType.MasterCard:
            //         integration2 = MasterCardIntegration();
            //         break;
            //     default:
            //         Console.WriteLine("Integration not found");
            //         break;
            // }
            //
            // //switch expression
            // var integration = cardType switch
            // {
            //     CardType.Elcart when isResident && customerType == CustomerType.PrivateCustomer => ElcardIntegration(),
            //     CardType.Visa => VisaIntegration(),
            //     _ => "integration is not supported"
            // };
            // Console.WriteLine(integration);
            //
            //
            // customerName = "Тест";
            // var customerSurname = "Тестов";
            // var customerLastname = "Тестович";
            // var customerBirthDate = DateTime.Parse("2015-05-14");
            // var customerBalance = 1500m;
            // var customerBalanceCurrency = Currencies.RUB;
            // Console.OutputEncoding = Encoding.UTF8;
            // Console.WriteLine(
            //     $"{customerSurname} {customerName} {customerLastname} his birthday {customerBirthDate:dd-MM-yy}\nHis balance = {customerBalance:N2} {getCurrencySymbol(customerBalanceCurrency)}");
            //
            // var customerBalances = new int[] {1500, 758, 5};
            //
            // // O Big O notation
            // // O(1)
            // // O(N)
            // // O(logN)
            // // O(N logN)
            // // O(N^2)
            // // O(N^3)
            // // O(N!)
            //
            // var text = "llllllllllll";
            // var isPalindrome = true;
            // for (int i = 0; i < text.Length / 2; i++)
            // {
            //     isPalindrome &= text[i] != text[text.Length - 1 - i];
            //     Console.WriteLine(i);
            // }
            //
            // Console.WriteLine(isPalindrome ? "Yes": "No");


            // const int AllowedConnections = 5;
            // const string BANKNAME = "OJSC BAKAI BANK";
            
            // + - * / %

            // var allowedConnections = 10;
            // var newConnectionsCount = 2;
            // allowedConnections = allowedConnections + newConnectionsCount;
            // allowedConnections += newConnectionsCount;
            // allowedConnections -= newConnectionsCount;
            // allowedConnections *= newConnectionsCount;
            // allowedConnections /= newConnectionsCount;
            // allowedConnections %= newConnectionsCount;

            // allowedConnections += 1;
            // allowedConnections++; // allowedConnections = allowedConnections + 1 
            // allowedConnections--; // allowedConnections = allowedConnections + 1 
            //
            // ++allowedConnections; //prefix increment
            // allowedConnections++; //postfix increment

            // Console.WriteLine(--allowedConnections + 5);
            // Console.WriteLine(allowedConnections);
            
            // && || ^
            // bool isCustomerValid = false;
            //
            // bool isCustomerNameValid = true;
            // bool isCustomerSurnameValid = false;
            // bool isCustomerSalaryValid = false;
            //
            // isCustomerValid = isCustomerValid && isCustomerNameValid;
            // isCustomerValid &= isCustomerNameValid;
            // isCustomerValid &= isCustomerSurnameValid;
            //
            // isCustomerValid |= isCustomerSalaryValid;
            
            // ? ??

            // Stack<int> stack = null;
            //
            // stack ??= new Stack<int>();

            // int? currencyID = null;
            // int customerCreditCurrencyID = 840;
            // customerCreditCurrencyID = currencyID ?? default; // null coalescing operator
            //
            // Console.WriteLine($"default  is: {default(bool)}");
            // if (currencyID is null)
            // {
            //     customerCreditCurrencyID = 417;
            // }
            // else
            // {
            //     customerCreditCurrencyID = (int) currencyID;
            // } 
            // customerCreditCurrencyID = currencyID == null ? 417 : currencyID;
            // var currencyText = currencyID.GetHashCode();
            // stack?.Push(customerCreditCurrencyID);
            // Console.WriteLine();

            // Console.WriteLine((int)cardType);
            // Console.WriteLine((CardType)cardTypeFromDb);
            
            
            //Collections

            // int[] shareholdersIDs = { 4578, 4152, 89798 };
            // var firstShareholder = shareholdersIDs[0];
            
            // ArrayList arrayList = new ArrayList();

            // arrayList.Add(true);
            // arrayList.Add(10);

            // var arrayListValue = arrayList[1];
            // Console.WriteLine("arrayListValue {0}", arrayListValue.GetType());

            // var shareholdersIdList = new List<int> {4545, 12, 4668};

            // shareholdersIdList.Add(796);
            // shareholdersIdList.AddRange(shareholdersIDs);

            // foreach (var shareholderID in shareholdersIdList)
            // {
            //     Console.WriteLine(shareholderID);
            // }
            
            // Hashtable hashtable = new Hashtable();
            
            // hashtable.Add("Elcard", "Элкарт");
            // hashtable.Add("MasterCard", "Мастер карт");
            // hashtable.Add("Visa", "Виза");

            var visaRuName = hashtable["Visa"];
            Console.WriteLine(hashtable["Visa"]);
            
            var currencies = new Dictionary<string, List<int>>();
            
            var wrongList = new List<object>{ 14 , 15, 16};
            
            // currencies.Add("Foreign currencies", new List<int>{840, 978, });
            // currencies.Add(417, "KGS");
            // currencies.Add(978, "EUR");

            foreach (var currency in currencies)
            {
                Console.WriteLine($"currency with code {currency.Key} is {currency.Value}");
            }
            
            
            

            // Console.WriteLine(shareholdersIDs.Length);
        }
    }
}