using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Messages
    {
        public static void SuccesMessage(string title)
        {
            Console.WriteLine($"{title} succesfully added");
        }

        public static void InputMessage(string title)
        {
            Console.WriteLine($" {title} adini qeyd edin:");
        }
        public static void NotFoundMessage(string title)
        {
            Console.WriteLine($"{title} not found");
        }

        public static void InvalidInputMessage(string title)
        {
            Console.WriteLine($"{title} is invalid, please try again");
        }
    }
}
