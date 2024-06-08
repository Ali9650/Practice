using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Group
    {
        private static int id = 1;
        public int Id { get; set; }

        public string Name { get; set; }
        public int Limit { get; set; }  

        public CustomList<Student> Students { get; set; }

        public Group(string name, int limit)
        {
            Id = id++;
            Name = name;
            Limit = limit;
            Students=new CustomList<Student>();
        }  
        public void GetDetails()
        {
            Console.WriteLine($"Id:{Id}, Name: {Name}, Limit: {Limit}");
        }
    }
}
