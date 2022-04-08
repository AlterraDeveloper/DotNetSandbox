using System;
using System.Text.RegularExpressions;

namespace DotnetSandbox
{
    public abstract class Customer
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

        public string IdentificationNumber { get; set; }
        
        public CustomerAddress Address { get; set; }

        // protected abstract bool ValidateIdentificationNumber(string identificationNumber);
        protected virtual bool ValidateIdentificationNumber(string identificationNumber)
        {
            return identificationNumber.Length == InnLength;
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
    }

    // class CustomerKG : Customer
    // {
    //     public string INN { get; set; }
    // }
    //
    // class CustomerTJ : Customer
    // {
    //     public string SIN { get; set; }
    //     public string IIIIN { get; set; }
    // }

    internal class PrivateCustomer : Customer
    {
        public string Surname { get; set; }

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
            var text =  base.ToString();
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
        public string StreetName { get; set; }
        public string HouseNo { get; set; }
    }
}