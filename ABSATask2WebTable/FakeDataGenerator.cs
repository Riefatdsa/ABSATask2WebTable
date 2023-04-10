using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSATask2WebTable
{
    class FakeDataGenerator
    {
        Random testvalue = new Random();
        public string GetRandomEmail()
        {
            string remail = $"Email{testvalue.Next().ToString()}@mail.com";
            return remail;
        }

        //if a random number is required
        public string GetRandomMobileSA()
        {
            string rmobile = $"27" + testvalue.Next(100000000).ToString();
            return rmobile;
        }

        public string GetUniqueUserName()
        {
            string rmobile = $"UName" + testvalue.Next(1000).ToString();
            return rmobile;
        }
    }
}
