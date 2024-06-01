using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Product
    {
        public Product(string name, int count, double price)
        {
            Name = name; Count = count; Price = price;
        }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
