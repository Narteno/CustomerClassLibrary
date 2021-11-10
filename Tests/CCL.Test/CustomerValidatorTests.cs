using Xunit;
using CustomerClassLibrary;
using System.Collections.Generic;

namespace CCL.Test
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void TestREQUIRED()
        {
            Address address = new Address("Address1", "Address2", AddressType.Shipping, "City", "Postal", "State", "Canada");
            Customer customer = new Customer("", "", null, "1231231234", "goneron@mail.ru", null, double.NaN);
            CustomerValidator CV = new CustomerValidator();
            List<string> expected = new List<string>()
            {
                "Last Name is REQUIRED",
                "There must be at least 1 element in the 'AddressesList'",
                "There must be at least 1 element in the 'Notes'"
            };
            Assert.Equal(expected, CV.CustomerValid(customer));
        }
        [Fact]
        public void TestMaxLength()
        {
            Address address = new Address("Address1", "Address2", AddressType.Shipping, "City", "Postal", "State", "Canada");
            Customer customer = new Customer("this string is too long! this string is too long!!!",
                "this string is too long! this string is too long!!!", 
                new List<Address> { address }, "1231231234", "goneron@mail.ru", new List<string> { "note" }, double.NaN);
            CustomerValidator CV = new CustomerValidator();
            List<string> expected = new List<string>()
            {
                "The maximum length of 'First Name' is 50 characters",
                "The maximum length of 'Last Name' is 50 characters"
            };
            Assert.Equal(expected, CV.CustomerValid(customer));
        }
        [Fact]
        public void TestPhoneAndEmail()
        {
            Address address = new Address("Address1", "Address2", AddressType.Shipping, "City", "Postal", "State", "Canada");
            Customer customer = new Customer("First Name", "Last Name", new List<Address> { address }, 
                "+7-1231231234", "gon@@eron@mail.ru", new List<string> { "note" }, double.NaN);
            CustomerValidator CV = new CustomerValidator();
            List<string> expected = new List<string>()
            {
                "The Phone Number must be in E.164 format",
                "Wrong E-mail address"
            };
            Assert.Equal(expected, CV.CustomerValid(customer));
        }
    }
}
