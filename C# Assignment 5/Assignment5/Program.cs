using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            //object creation
            PrimeMinisterDictionary PMObj = new PrimeMinisterDictionary();

            PMObj.DetailedDictionary();
            PMObj.FindPM();
            PMObj.AddPM();
            PMObj.sort();
        }
    }
}
