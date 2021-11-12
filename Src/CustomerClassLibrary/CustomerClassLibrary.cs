using System.Collections.Generic;

namespace CustomerClassLibrary
{
    public abstract class Person
    {
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set;}
    }
    public class Customer : Person
    {
        public Customer(string FirstName, string LastName, List<Address> AddressesList,
            string PhoneNumber, string Email, List<string> Notes, double TotalPurchasesAmount) : base(FirstName,LastName)
        {
            this.AddressesList = AddressesList;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Notes = Notes;
            this.TotalPurchasesAmount = TotalPurchasesAmount;
        }
        public List<Address> AddressesList { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Notes { get; set; }
        public double TotalPurchasesAmount { get; set; }
    }
    public class Address
    { 
        public Address(string AddressLine, string AddressLine2, AddressType Address_Type, 
            string City, string PostalCode,string State,string Country)
        {
            this.AddressLine = AddressLine; this.AddressLine2 = AddressLine2;
            this.Address_Type = Address_Type; this.City = City; this.PostalCode = PostalCode;
            this.State = State; this.Country = Country;
        }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public AddressType Address_Type { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public enum AddressType
    {
        Shipping,
        Billing
    }
}
