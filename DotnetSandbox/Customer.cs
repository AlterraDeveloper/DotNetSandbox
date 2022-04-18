using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotnetSandbox
{
    public abstract partial class Customer
    {
        public Customer()
        {
        }

        public Customer(string inn)
        {
            // if (ValidateIdentificationNumber(inn)) 
            IdentificationNumber = inn;
            Console.WriteLine("construct Customer");
        }

        protected const int InnLength = 14;

        public int CustomerID { get; set; }

        public List<Account> Accounts
        {
            get;
            set;
        }

        public string IdentificationNumber { get; set; }

        public CustomerAddress Address { get; set; }

        // protected abstract bool ValidateIdentificationNumber(string identificationNumber);
    }

    public class PrivateCustomer : Customer
    {
        private string _surname;
        
        public string Surname
        {
            get
            {
                return _surname;
            }
            
            set
            {
                _surname = value;
            }
        }
        

        public string CustomerName { get; set; }

        public PrivateCustomer()
        {
            Console.WriteLine("construct PrivateCustomer");
        }

        public PrivateCustomer(string inn, string name) : base(inn)
        {
            CustomerName = name;
        }

        protected override bool ValidateIdentificationNumber(string identificationNumber)
        {
            return base.ValidateIdentificationNumber(identificationNumber)
                   && Regex.IsMatch(identificationNumber, "[12]{1}\\d{13}");
        }

        public override string ToString()
        {
            var text = base.ToString();
            return text + "111";
        }
    }

    public class LegalCustomer : Customer
    {
        string CompanyName { get; set; }

        public string Okpo { get; set; }

        public string SocialFondCode { get; set; }

        public LegalCustomer(string inn, string name) : base(inn)
        {
            CompanyName = name;
            Console.WriteLine("construct LegalCustomer");
        }

        protected override bool ValidateIdentificationNumber(string identificationNumber)
        {
            return base.ValidateIdentificationNumber(identificationNumber)
                   && Regex.IsMatch(identificationNumber, "0\\d{13}");
        }
    }

    public class CustomerAddress
    {
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public CustomerAddressDetails AddressDetails { get; set; }
    }

    public class CustomerAddressDetails
    {
        public string StreetName { get; set; }
        public string HouseNo { get; set; }
    }
}