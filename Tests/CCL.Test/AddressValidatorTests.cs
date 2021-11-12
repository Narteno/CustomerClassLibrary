using Xunit;
using CustomerClassLibrary;
using System.Collections.Generic;

namespace CCL.Test
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldNotBeEmpty()
        {
            Address address = new Address("", "none", AddressType.Billing, "", "", "", "");
            AddressValidator validator = new AddressValidator();
            List<string> expected = new()
            {
                "Address Line is REQUIRED",
                "City is REQUIRED",
                "Postal Code is REQUIRED",
                "State is REQUIRED",
                "Country is REQUIRED"
            };
            Assert.Equal(expected, validator.RunAddressValidator(address));
        }
        [Fact]
        public void ShouldNotBeTooLong()
        {
            Address address = new Address("this string is too long! this string is too long! this string is too long! this string is too long!!!",
                "this string is too long! this string is too long! this string is too long! this string is too long!!!", 
                AddressType.Billing, "this string is too long! this string is too long!!!", 
                "1231234", "this string is too long!", "Canada");
            AddressValidator validator = new AddressValidator();
            List<string> expected = new()
            {
                "The maximum length of 'Address Line' is 100 characters",
                "The maximum length of 'Address Line 2' is 100 characters",
                "The maximum length of 'City' is 50 characters",
                "The maximum length of 'Postal Code' is 6 characters",
                "The maximum length of 'State' is 20 characters"

            };
            Assert.Equal(expected, validator.RunAddressValidator(address));
        }
        [Fact]
        public void CountryShouldBeAbleEqual()
        {
            Address address = new Address("Address1", "Address2", AddressType.Shipping, "City",
                "Postal", "State", "Texas");
            List<string> expected = new() { "Country should be 'Unated States' or 'Canada'" };
            AddressValidator validator = new AddressValidator();
            Assert.Equal(expected, validator.RunAddressValidator(address));
            address = new Address("Address1", "Address2", AddressType.Shipping, "City",
                "Postal", "State", "Canada");
            expected = new List<string>();
            Assert.Equal(expected, validator.RunAddressValidator(address));
        }
    }
}
