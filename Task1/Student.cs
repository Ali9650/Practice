using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Student
    {
        private static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public DateTime BirhDate  { get; set; }
        public CustomList<decimal> Grades { get; set; }
        
        public Student(string name, string surname, DateTime birhDate)
        {
            Id = id++;
            Name = name;
            Surname = surname;  
            BirhDate = birhDate;  
        }
        public void GetDetails()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Surname: {Surname}, BirhDate: {BirhDate.ToString("dd.MM.yyyy")}");
        }
    }
}
