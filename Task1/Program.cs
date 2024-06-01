using System.ComponentModel.Design;
using System.Globalization;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("Code Academy");
            while (true)
            {
            Menu: Console.WriteLine("--Menu--");
                Console.WriteLine("1.Qrup elave et");
                Console.WriteLine("2.Qrupu redakte et");
                Console.WriteLine("3.Qrupu sil");
                Console.WriteLine("4.Qruplari gor");
                Console.WriteLine("5.Qrupa telebe eleve et");
                Console.WriteLine("6.Kursdaki telebelerin siyahisi");
                Console.WriteLine("7.Qrupdaki telebelerin siyahisi");
                Console.WriteLine("8.Telebeler uzre axtaris");
                Console.WriteLine("9.Qrupdan telebeni sil");
                Console.WriteLine("10.Qrupdaki telebeleri redakte et");
                Console.WriteLine("0.Exit");

                Console.WriteLine("---Secim edin---");



                string input = Console.ReadLine();
                int result;
                bool IsSucceeded = int.TryParse(input, out result);
                if (IsSucceeded)
                {
                    switch (result)
                    {
                        case (int)Operations.AddGroup:
                        InputGroupName: Console.WriteLine("Qrup adini daxil edin");
                            string name = Console.ReadLine();
                            if (name.IsValidGroupName())
                            {
                                if (!course.Groups.Any(g => g.Name.ToLower() == name.ToLower()))
                                {
                                InputLimitDesc: Console.WriteLine("Limit daxil edin");
                                    input = Console.ReadLine();
                                    int limit;
                                    IsSucceeded = int.TryParse(input, out limit);
                                    if (IsSucceeded)
                                    {
                                        course.AddGroup(new Group(name, limit));
                                        Console.WriteLine("Qrup ugurla elave olundu");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Daxil edilen limit duzgun formatda deyil, zehmet olmasa limiti yeniden daxil edin");
                                        goto InputLimitDesc;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Bu qrup artiq movcuddur");
                                }
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessage.InvalidGroupNameFormat);
                                goto InputGroupName;
                            }
                            break;
                        case (int)Operations.ViewGroup:
                            course.GetAllGroups();
                            break;
                        case (int)Operations.UpdateGroup:
                            course.GetAllGroups();
                        UpdateGroupDescription: Console.WriteLine("Redakte etmek istediyiniz qrupun id-sini secin");
                            input = Console.ReadLine();
                            int id;
                            IsSucceeded = int.TryParse(input, out id);
                            if (IsSucceeded)
                            {
                                var existGroup = course.Groups.FirstOrDefault(x => x.Id == id);
                                if (existGroup is not null)
                                {
                                    Console.WriteLine("Qrupun yeni adini daxil edin");
                                    string newName = Console.ReadLine();
                                    if (newName.IsValidGroupName())
                                    {
                                        if (!course.Groups.Any(g => g.Name == newName))
                                        {
                                            existGroup.Name = newName;
                                            Console.WriteLine("Qrup adi ugurla deyisdirildi");
                                        }
                                        else
                                            Console.WriteLine("Daxil etdiyiniz adda qrup var");
                                    }
                                    else
                                        Console.WriteLine(ErrorMessage.InvalidGroupNameFormat);
                                }
                                else
                                    Console.WriteLine(ErrorMessage.GroupNotFound);
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessage.InvalidIdFormat);
                                goto UpdateGroupDescription;
                            }
                            break;
                        case (int)Operations.DeleteGroup:
                            course.GetAllGroups();
                            Console.WriteLine("Silmek istediyiniz qrup Id-sini secin");
                            input = Console.ReadLine();
                            IsSucceeded = int.TryParse(input, out id);
                            if (IsSucceeded)
                            {
                                var existGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                                if (existGroup is not null)
                                {
                                    course.Groups.Remove(existGroup);
                                    Console.WriteLine($"{existGroup.Name} silindi");
                                }
                                else
                                    Console.WriteLine(ErrorMessage.GroupNotFound);
                            }
                            else
                                Console.WriteLine(ErrorMessage.InvalidIdFormat);
                            break;
                        case (int)Operations.AddStudentToGroup:
                            course.GetAllGroups();
                        AddStudentToGroupDescription: Console.WriteLine("Telebe elave etmek istediyiniz qrupun id-sini secin");
                            input = Console.ReadLine();
                            IsSucceeded = int.TryParse(input, out id);
                            if (IsSucceeded)
                            {
                                var existGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                                if (existGroup is not null)
                                {
                                InputStudentNameDesc: Console.WriteLine("Telebe adini daxil edin");
                                    name = Console.ReadLine();
                                    if (!name.IsValidStudentName())
                                        goto InputStudentNameDesc;

                                    Console.WriteLine("Telebenin soyadini daxil edin");
                                    var surname = Console.ReadLine();
                                    if (!surname.IsValidStudentSurname())
                                        goto InputStudentNameDesc;
                                    Console.WriteLine("Telebenin tevelludunu daxil edin(02.06.1996)");
                                    input = Console.ReadLine();
                                    DateTime birhDate;
                                    IsSucceeded = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birhDate);
                                    if (IsSucceeded)
                                    {
                                        var student = new Student(name, surname, birhDate);
                                        existGroup.Students.Add(student);
                                        Console.WriteLine($"{student.Name} {student.Surname} {existGroup.Name} qrupa ela");
                                        existGroup.Students.Add(new Student(name, surname, birhDate));
                                    }
                                    else
                                        Console.WriteLine(ErrorMessage.InvalidFormat);
                                }
                                else
                                    Console.WriteLine(ErrorMessage.GroupNotFound);
                            }
                            else
                                Console.WriteLine(ErrorMessage.InvalidIdFormat);
                            break;

                        case (int)Operations.ListofStudentsInGroup:
                            course.GetAllGroups();
                            input = Console.ReadLine();
                            IsSucceeded = int.TryParse(input, out id);
                            if (IsSucceeded)
                            {
                                var existGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                                if (existGroup is not null)
                                {
                                    foreach (var student in existGroup.Students)
                                        student.GetDetails();
                                }
                                else
                                    Console.WriteLine(ErrorMessage.GroupNotFound);
                            }
                            else
                                Console.WriteLine(ErrorMessage.InvalidIdFormat);
                            break;
                        case (int)Operations.ListofStudentsInCourse:
                            var allStudents = course.GetAllStudents();
                            foreach (var student in allStudents)
                            {
                                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, BirhDate: {student.BirhDate}");
                            }
                            break;
                        case (int)Operations.SearchStudent:
                            Console.WriteLine("Telebelerin axtarisi ucun olan deyeri daxil edin:");
                            string searchTerm = Console.ReadLine();

                            Console.WriteLine($"Students matching '{searchTerm}':");
                            foreach (var group in course.Groups)
                            {
                                foreach (var student in group.Students)
                                {
                                    if (student.Name.Contains(searchTerm))
                                    {
                                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname} Group: {group.Name}");
                                    }
                                }
                            }
                            break;
                        case (int)Operations.RemoveStudentFromGroup:
                            course.GetAllGroups();
                            Console.WriteLine("Secmek istediyiniz qrupu yazin:");
                            foreach (var group in course.Groups)
                            {
                                Console.WriteLine($"Group Name: {group.Name}");
                            }

                            Console.WriteLine("Telebeni silmek istediyiniz qrupu secin:");
                            string groupName = Console.ReadLine();

                            var selectedGroup = course.Groups.FirstOrDefault(g => g.Name == groupName);
                            if (selectedGroup != null)
                            {
                                Console.WriteLine($"Students in group {groupName}:");
                                foreach (var student in selectedGroup.Students)
                                {
                                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                                }

                                Console.WriteLine("Silmek istediyiniz telebenin Id-sini daxil edin:");
                                int studentId = int.Parse(Console.ReadLine());

                                var studentToRemove = selectedGroup.Students.FirstOrDefault(s => s.Id == studentId);
                                if (studentToRemove != null)
                                {
                                    selectedGroup.Students.Remove(studentToRemove);
                                    Console.WriteLine("Telebe qrupdan silindi");
                                }
                                else
                                {
                                    Console.WriteLine(ErrorMessage.InvalidIdFormat);
                                }
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessage.GroupNotFound);
                            }
                            break;

                        case (int)Operations.UpdateStudent:
                            course.GetAllGroups();
                            Console.WriteLine("Secmek istediyiniz qrupu yazin:");
                            foreach (var group in course.Groups)
                            {
                                Console.WriteLine($"Group Name: {group.Name}");
                            }

                            Console.WriteLine("Melumatlarini deyismek istediyiniz telebenin qrupunu yazin:");
                            groupName = Console.ReadLine();

                            selectedGroup = course.Groups.FirstOrDefault(g => g.Name == groupName);
                            if (selectedGroup != null)
                            {
                                Console.WriteLine($"Students in group {groupName}:");
                                foreach (var student in selectedGroup.Students)
                                {
                                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                                }

                                Console.WriteLine("Melumatlarini deyismek istediyiniz telebenin ID-sini yazin:");
                                int studentId = int.Parse(Console.ReadLine());

                                var studentToEdit = selectedGroup.Students.FirstOrDefault(s => s.Id == studentId);
                                if (studentToEdit != null)
                                {
                                    Console.WriteLine("Telebenin yeni melumatlarini elave edin:");
                                    Console.Write("Ad: ");
                                    studentToEdit.Name = Console.ReadLine();
                                    Console.Write("Soyad: ");
                                    studentToEdit.Surname = Console.ReadLine();



                                    Console.WriteLine("Telebenin melumatlari yenilendi");
                                }
                                else
                                {
                                    Console.WriteLine(ErrorMessage.InvalidIdFormat);
                                }
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessage.GroupNotFound);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    goto Menu;
                }

            }

        }
    }
}

