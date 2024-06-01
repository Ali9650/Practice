using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    public static class StringExtensions
    {
        public static bool IsValidGroupName(this string name)
        {
            if(!string.IsNullOrWhiteSpace(name) && name.Length > 3)
            {
                return true;
            }
            return false;
        }
        public static bool IsValidStudentName (this string name) 
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length > 3 && Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidStudentSurname(this string surname)
        {
            if (!string.IsNullOrWhiteSpace(surname) && surname.Length > 3 && Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }
    }
}
