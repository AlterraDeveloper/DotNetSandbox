namespace DotnetSandbox
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string IdentificationNumber { get; set; }
    }

    public class PrivateCustomer : Customer
    {
        public string Surname { get; set; }

        public string CustomerName { get; set; }

    }
}