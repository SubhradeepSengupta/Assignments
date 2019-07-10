using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Products ProdObj = new Products();

            ProdObj.getDetails();
            Console.WriteLine("Total No of Products : " +ProdObj.ProductCount());
            ProdObj.ProductAdd();
            ProdObj.AllLeafyGreen();
            ProdObj.RemovingGarlic();
            ProdObj.CabageQuantity();
            ProdObj.TotalAmount();
        }
    }
}
