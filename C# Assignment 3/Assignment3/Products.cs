using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Products
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductType { get; set; }
        private decimal Amount;
        private int productcount;

        public List<Products> ProductList = new List<Products>();

        public void getDetails()
        {
            ProductList.Add(new Products()
            { ProductName = "lettuce", ProductPrice = 10.5m, ProductQuantity = 50, ProductType = "Leafy green" });
            ProductList.Add(new Products()
            { ProductName = "cabbage", ProductPrice = 20, ProductQuantity = 100, ProductType = "Cruciferous" });
            ProductList.Add(new Products()
            { ProductName = "pumpkin", ProductPrice = 30, ProductQuantity = 30, ProductType = "Marrow" });
            ProductList.Add(new Products()
            { ProductName = "cauliflower", ProductPrice = 10, ProductQuantity = 25, ProductType = "Cruciferous" });
            ProductList.Add(new Products()
            { ProductName = "zucchini", ProductPrice = 20.5m, ProductQuantity = 50, ProductType = "Marrow" });
            ProductList.Add(new Products()
            { ProductName = "yam", ProductPrice = 30, ProductQuantity = 50, ProductType = "Root" });
            ProductList.Add(new Products()
            { ProductName = "spinach", ProductPrice = 10, ProductQuantity = 100, ProductType = "Leafy green" });
            ProductList.Add(new Products()
            { ProductName = "broccoli", ProductPrice = 20.2m, ProductQuantity = 75, ProductType = "Cruciferous" });
            ProductList.Add(new Products()
            { ProductName = "garlic", ProductPrice = 30, ProductQuantity = 20, ProductType = "Leafy green" });
            ProductList.Add(new Products()
            { ProductName = "silverbeet", ProductPrice = 10, ProductQuantity = 50, ProductType = "Marrow" });
        }

        public int ProductCount()
        {
            productcount = ProductList.Count();
            return productcount;
        }

        public void ProductAdd()
        {
            Console.WriteLine();
            Console.WriteLine("Adding a new product");
            ProductList.Add(new Products()
            { ProductName = "Potato", ProductPrice = 10, ProductQuantity = 50, ProductType = "Root" });

            foreach (var product in ProductList)
            {
                Console.WriteLine("Product : " + product.ProductName + ", " + product.ProductPrice + ", " + product.ProductQuantity + ", " + product.ProductType);
            }
            Console.WriteLine();
            productcount = ProductList.Count();
            Console.WriteLine("Total Number Of Product(after adding) : " + productcount);
        }

        public void AllLeafyGreen()
        {
            Console.WriteLine();
            Console.WriteLine("Products of type Leafy Green : ");
            foreach (var product in ProductList)
            {
                if (product.ProductType == "Leafy green")
                {
                    Console.WriteLine("Product : " + product.ProductName + ", " + product.ProductPrice + ", " + product.ProductQuantity + ", " + product.ProductType);
                }
            }
        }

        public void RemovingGarlic()
        {
            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].ProductName.Equals("garlic"))
                {
                    ProductList.RemoveAt(i);
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total No Of Products after garlic is removed : " + ProductList.Count());
        }

        public void CabageQuantity()
        {
            foreach (var product in ProductList)
            {
                if (product.ProductName.Equals("cabbage"))
                {
                    product.ProductQuantity += 50;
                    Console.WriteLine();
                    Console.WriteLine("Number of cabbages after adding 50 more : " +product.ProductQuantity);
                }
            }
        }

        public void TotalAmount()
        {
            

            foreach (var product in ProductList)
            {
                if (product.ProductName.Equals("lettuce"))
                    Amount += (product.ProductPrice);

                if(product.ProductName.Equals("zucchini"))
                    Amount += (2*product.ProductPrice);

                if (product.ProductName.Equals("broccoli"))
                    Amount += (product.ProductPrice);
            }
            Console.WriteLine();
            Console.WriteLine("The total amount will be : " +Math.Round(Amount));
        }
    }
}
