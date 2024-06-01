using Microsoft.VisualBasic;
using static Task2.Coffe;
using static Task2.Te;

namespace Task2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Operation choice;


            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Product elave edin");
                Console.WriteLine("2. Product satin");
                Console.WriteLine("3. Gelire baxin");
                Console.WriteLine("4. Qalan producta baxin");
                Console.WriteLine("5. Cixis");

                Console.Write("Seciminizi edin: ");
                choice = (Operation)int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case Operation.AddProduct:
                        Console.WriteLine("Enter product type(c --> coffee , t --> tea):");
                        char productType = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("Enter product name:");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Enter product price");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter product count:");
                        int count = Convert.ToInt32(Console.ReadLine());

                        if (productType == 't')
                        {
                            shop.AddProduct(new Tea(productName, count, price));
                        }
                        else if (productType == 'c')
                        {
                            shop.AddProduct(new Coffee(productName, count, price));
                        }
                        else
                        {
                            Console.WriteLine("Invalid type");
                        }

                        break;

                    case Operation.SellProduct:
                        Console.Write("Satin alinacak mehsulun adi: ");
                         productName = Console.ReadLine();

                        Console.Write("Satin alinacak sayi: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        shop.SellProduct(productName, quantity);
                        break;

                    case Operation.TotalInCome:
                        Console.WriteLine("Toplam gelir: {0}", shop.TotalIncome);
                        break;

                    case Operation.DisplayAvailableProducts:
                        shop.DisplayAvailableProducts();
                        break;

                    case Operation.Exit:
                        Console.WriteLine("Exit"); ;
                        break;

                    default:
                        Console.WriteLine("Yanlis secim!");
                        break;
                }
            }
        }
    }
}
