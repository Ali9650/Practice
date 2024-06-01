using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Shop
    {
        private List<Product> products = new List<Product>();
        public double TotalIncome { get; private set; }

        public void AddProduct(Product product)
        {
            if (!products.Any(p => p.Name == product.Name))
            {
                products.Add(product);
                Console.WriteLine("Product elave olundu: {0}", product.Name);
            }
            else
            {
                Console.WriteLine("Bu adla product artiq movcuddur!");
            }
        }

        public void SellProduct(string productName, int quantity)
        {
            Product product = products.FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                if (product.Count >= quantity)
                {
                    product.Count -= quantity;
                    double income = product.Price * quantity;
                    TotalIncome += income;
                    Console.WriteLine("{0} mehsuldan {1} eded satildi. Gelir: {2}", productName, quantity, income);
                    if (product.Count == 0)
                        products.Remove(product);
                }
                else
                {
                    Console.WriteLine("Yeterli sayda mehsul yoxdur!");
                }
            }
            else
            {
                Console.WriteLine("Mehsul tapilmadi!");
            }
        }

        public void DisplayAvailableProducts()
        {
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine("Name: {0}, Price: {1}, Count: {2}", product.Name, product.Price, product.Count);
            }
        }
    }}