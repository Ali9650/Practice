

namespace Task3
{
    internal class Hospital
    {
        private List<Doctor> doctors;

        public Hospital()
        {
            doctors = new List<Doctor>();
        }


        public void AddDoctor()
        {
            Console.WriteLine("Enter doctor's name:");
            string name = Console.ReadLine();
            doctors.Add(new Doctor(name));
            Console.WriteLine("Doctor added successfully!");
        }

        public void ViewAllDoctors()
        {
            Console.WriteLine("List of Doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.Name);
            }
        }


        public void ScheduleAppointment()
        {
            Console.WriteLine("Enter patient's name:");
            string patientName = Console.ReadLine();

            Console.WriteLine("Enter appointment date (yyyy-MM-dd HH:mm):");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);


            bool isSlotAvailable = true;
            foreach (var doctor in doctors)
            {
                foreach (var appointment in doctor.Appointments)
                {

                    if ((date - appointment.Date).TotalHours < 1 && (date - appointment.Date).TotalHours > -1)
                    {
                        isSlotAvailable = false;
                        break;
                    }
                }
                if (!isSlotAvailable)
                    break;
            }

            if (isSlotAvailable)
            {
                Console.WriteLine("Select doctor:");
                for (int i = 0; i < doctors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {doctors[i].Name}");
                }
                int choice = int.Parse(Console.ReadLine());
                doctors[choice - 1].Appointments.Add(new Appointment(patientName, date));
                Console.WriteLine("Appointment scheduled successfully!");
            }
            else
            {
                Console.WriteLine("Selected time slot is not available. Please choose another time.");
            }
        }


        public void ViewAppointmentsOfDoctor()
        {
            Console.WriteLine("Enter doctor's name:");
            string doctorName = Console.ReadLine();

            Doctor doctor = doctors.Find(d => d.Name == doctorName);
            if (doctor != null)
            {
                Console.WriteLine($"Appointments of {doctorName}:");
                foreach (var appointment in doctor.Appointments)
                {
                    Console.WriteLine($"Patient: {appointment.PatientName}, Date: {appointment.Date}");
                }
            }
            else
            {
                Console.WriteLine("Doctor not found!");
            }
        }
    }
}
