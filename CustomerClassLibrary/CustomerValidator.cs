using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    public class CustomerValidator
    {
        public List<string> CustomerValid(Customer customer)
        {
            List<string> outputMessage = new();
            if (customer.FirstName.Length > 50) outputMessage.Add("The maximum length of 'First Name' is 50 characters");
            if (customer.LastName == string.Empty) outputMessage.Add("Last Name is REQUIRED");
            if (customer.LastName.Length > 50) outputMessage.Add("The maximum length of 'Last Name' is 50 characters");
            if (customer.AddressesList == null) outputMessage.Add("There must be at least 1 element in the 'AddressesList'");
            if(!Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
                outputMessage.Add("The Phone Number must be in E.164 format");
            if (!Regex.IsMatch(customer.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                outputMessage.Add("Wrong E-mail address");
            if (customer.Notes == null) outputMessage.Add("There must be at least 1 element in the 'Notes'");
            return outputMessage;
        }
    }
}
