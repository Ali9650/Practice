using System.Linq.Expressions;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            Information choice;

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add doctor");
                Console.WriteLine("2. View all doctors");
                Console.WriteLine("3. Schedule appointment");
                Console.WriteLine("4. View appointments of doctor");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                choice = (Information)int.Parse(Console.ReadLine());


                switch (choice)
                {

                    case Information.AddDoctor:
                        hospital.AddDoctor();
                        break;
                    case Information.ViewAllDoctors:
                        hospital.ViewAllDoctors();
                        break;
                    case Information.ScheduleAppointment:
                        hospital.ScheduleAppointment();
                        break;
                    case Information.ViewAppointmentsofDoctor:
                        hospital.ViewAppointmentsOfDoctor();
                        break;
                    case Information.Exit:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
