using System;
using Xunit;
using CustomerClassLibrary;
using System.Collections.Generic;

namespace CCL.Test
{
    public class CustomerClassLibraryTests
    {
        [Fact]
        public void TestPerson()
        {
            Address address = new Address("Leningradskaya 12", "", AddressType.Billing, "", "23452345", "", "");
            Customer customer = new("Ilya", "Krasnoperov", new List<Address> { address }, 
                "+12746178246","goneron@mail.ru",null,50);
        }
    }
}
