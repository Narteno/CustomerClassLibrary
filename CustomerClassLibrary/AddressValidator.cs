using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    public class AddressValidator
    {
        public List<string> AddressValid(Address address)
        {
            List<string> outputMessage = new List<string>();
            if (address.AddressLine == string.Empty) outputMessage.Add("Address Line is REQUIRED");
            if (address.AddressLine.Length > 100) outputMessage.Add("The maximum length of 'Address Line' is 100 characters");
            if (address.AddressLine2.Length > 100) outputMessage.Add("The maximum length of 'Address Line 2' is 100 characters");
            if (address.City == string.Empty) outputMessage.Add("City is REQUIRED");
            if (address.City.Length > 50) outputMessage.Add("The maximum length of 'City' is 50 characters");
            if (address.PostalCode == string.Empty) outputMessage.Add("Postal Code is REQUIRED");
            if (address.PostalCode.Length > 6) outputMessage.Add("The maximum length of 'Postal Code' is 6 characters");
            if (address.State == string.Empty) outputMessage.Add("State is REQUIRED");
            if (address.State.Length > 6) outputMessage.Add("The maximum length of 'State' is 20 characters");
            if (address.Country == string.Empty) outputMessage.Add("Country is REQUIRED");
            else if (address.Country.ToLower() != "united states" && address.Country.ToLower() != "canada")
                outputMessage.Add("Country should be 'Unated States' or 'Canada'");
            return outputMessage;
        }
    }
}
