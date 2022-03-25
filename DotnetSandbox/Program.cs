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
            // var list = new List<int>{1,2,3};
            // var list2 = new List<int>{1,2,3};
            //
            // var number = 5;
            // var number2 = 5;
            //
            // Console.WriteLine(list.GetHashCode());
            // Console.WriteLine(list2.GetHashCode());
            // Console.WriteLine(number.GetHashCode());
            // Console.WriteLine(number2.GetHashCode());

            // Множество
            HashSet<int> hashSet = new HashSet<int>();

            hashSet.Add(5);
            hashSet.Add(4);
            hashSet.Add(3);
            hashSet.Add(3);
            hashSet.Add(3);

            var list = new List<int> {1, 1, 2, 2, 3, 3};

            hashSet.Clear();

            hashSet = new HashSet<int>(list);

            var modifiedPropertiesSet = new HashSet<string>
            {
                "Surname",
                "DocumentTypeID",
                "DocumentSeries",
                "ResidenceStreet",
                "ResidenceHouse",
                "NationalityID"
            };

            var propertiesForAuthorize = new HashSet<string>
            {
                "Surname",
                "Name",
                "DocumentTypeID",
                "DocumentSeries",
                "IdentificationNumber"
            };
            propertiesForAuthorize.IntersectWith(modifiedPropertiesSet);
            foreach (var prop in propertiesForAuthorize)
            {
                Console.WriteLine($"Property {prop} need for authorize");
            }

            var accounts = new List<Tuple<string, int>>
            {
                Tuple.Create("12158917898189", 417),
                Tuple.Create("12158917898189", 840),
                Tuple.Create("12158917898189", 986),
                Tuple.Create("00000000489494", 986),
                Tuple.Create("00000000489494", 417),
            };

            foreach (var accountNo in new HashSet<string>(accounts.Select(x => x.Item1)))
            {
                Console.WriteLine("Client accounts: {0}", accountNo);
            }

            foreach (var currencyID in accounts.Select(x => x.Item2).Distinct())
            {
                Console.WriteLine("Client accounts: {0}", currencyID);
            }

            var loanGraphic = new List<Tuple<DateTime, decimal>>
            {
                Tuple.Create(new DateTime(2022, 1, 5), 5000m),
                Tuple.Create(new DateTime(2022, 2, 5), 5000m),
                Tuple.Create(new DateTime(2022, 3, 5), 5000m),
                Tuple.Create(new DateTime(2022, 4, 5), 5000m),
                Tuple.Create(new DateTime(2022, 5, 5), 5000m),
                Tuple.Create(new DateTime(2022, 6, 5), 5000m),
            };

            var loanPercentsGraphic = new List<Tuple<DateTime, decimal>>
            {
                Tuple.Create(new DateTime(2022, 1, 5), 1000m),
                Tuple.Create(new DateTime(2022, 2, 5), 1000m),
                Tuple.Create(new DateTime(2022, 3, 5), 1000m),
                Tuple.Create(new DateTime(2022, 4, 5), 1000m),
                Tuple.Create(new DateTime(2022, 5, 5), 1000m),
                Tuple.Create(new DateTime(2022, 6, 5), 1000m),
            };

            //FIFO = first in first out
            var queue = new Queue<int>();

            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(3);

            foreach (var queueValue in queue)
            {
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
// var requestList = new List<string>();
//             do
//             {
//                 requestList = HttpClient.Fetch()
//             } while (requestList.Count > 0);

            //LIFO = last in first out
            var text = "qwerty";
            var stack = new Stack<char>(text);
            foreach (var _char in stack)
            {
                Console.Write(_char);
            }


            Console.ReadKey();
        }
    }
}