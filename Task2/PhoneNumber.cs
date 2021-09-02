using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task2
{
    class PhoneNumber
    {
        Dictionary<string, string> CountryCodes = new Dictionary<string, string>();
        public string Number { get; set; }
        public List<string> CountryList { get; set; } = new List<string>();
        public PhoneNumber()
        {
            CountryList.AddRange(new string[] { "Ukraine", "Russia", "SC", "SC2" });
            CountryCodes.Add("Ukraine", "+380");
            CountryCodes.Add("Russia", "+7");
            CountryCodes.Add("SC", "+423");
            CountryCodes.Add("SC2", "+88");
        }

        public bool CreateNumber(string nameOfCountry, int number)
        {
            Number = CountryCodes.Select(x => x.Key == nameOfCountry ? x.Value : "NONE").First();
            Number += number;
            return true;
        }
        public override string ToString()
        {
            return Number;
        }
    }
}
