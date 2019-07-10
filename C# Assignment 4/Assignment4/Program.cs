using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //object creation
            Arrays ArrayObj = new Arrays();

            ArrayObj.AddWords();
            ArrayObj.WordPlurals();
            ArrayObj.ReplaceWithSynonym();
            ArrayObj.AddNewWord();
            ArrayObj.LengthEqualsSeven();
            ArrayObj.WordOnThirdPosition();
            ArrayObj.Sort();
            ArrayObj.Reverse();
        }
    }
}
