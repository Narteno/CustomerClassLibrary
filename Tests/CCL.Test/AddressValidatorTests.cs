using Xunit;
using CustomerClassLibrary;
using System.Collections.Generic;

namespace CCL.Test
{
    public class AddressValidatorTests
    {
        [Fact]
        public void TestREQUIRED()
        {
            Address address = new Address("", "none", AddressType.Billing, "", "", "", "");
            AddressValidator AV = new AddressValidator();
            List<string> expected = new()
            {
                "Address Line is REQUIRED",
                "City is REQUIRED",
                "Postal Code is REQUIRED",
                "State is REQUIRED",
                "Country is REQUIRED"

            };
            Assert.Equal(expected, AV.AddressValid(address));
        }
        [Fact]
        public void TestMaxChar()
        {
            Address address = new Address("this string is too long! this string is too long! this string is too long! this string is too long!!!",
                "this string is too long! this string is too long! this string is too long! this string is too long!!!", 
                AddressType.Billing, "this string is too long! this string is too long!!!", 
                "1231234", "this string is too long!", "Canada");
            AddressValidator AV = new AddressValidator();
            List<string> expected = new()
            {
                "The maximum length of 'Address Line' is 100 characters",
                "The maximum length of 'Address Line 2' is 100 characters",
                "The maximum length of 'City' is 50 characters",
                "The maximum length of 'Postal Code' is 6 characters",
                "The maximum length of 'State' is 20 characters"

            };
            Assert.Equal(expected, AV.AddressValid(address));
        }
        [Fact]
        public void TestCountry()
        {
            Address address = new Address("Address1", "Address2", AddressType.Shipping, "City",
                "Postal", "State", "Texas");
            List<string> expected = new() { "Country should be 'Unated States' or 'Canada'" };
            AddressValidator AV = new AddressValidator();
            Assert.Equal(expected, AV.AddressValid(address));
            address = new Address("Address1", "Address2", AddressType.Shipping, "City",
                "Postal", "State", "Canada");
            expected = new List<string>();
            Assert.Equal(expected, AV.AddressValid(address));
        }
    }
}
