

namespace Task3
{
    public  class Hospital
    {
        private List<Doctor> doctors;

        public Hospital()
        {
            doctors = new List<Doctor>();
        }


        public void AddDoctor()
        {
            Messages.InputMessage("Doctor");
            string name = Console.ReadLine();
            doctors.Add(new Doctor(name));
            Messages.SuccesMessage("Doctor");           
        }

        public void ViewAllDoctors()
        {
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.Name);
            }
        }

        public void ScheduleAppointment()
        {
            Messages.InputMessage("Doctor");
            string doctorName = Console.ReadLine();
            
            Doctor doctor = doctors.Find(d => d.Name == doctorName);

            if (doctor != null)
            {
                Messages.InputMessage("Pasient");
                string patientName = Console.ReadLine();

                
                Console.WriteLine($"Enter appointment date and time for Dr. {doctor.Name} (yyyy-MM-dd HH:mm):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDate))
                {
                    
                    doctor.ScheduleAppointment(patientName, appointmentDate);
                    Messages.SuccesMessage("ScheduleAppointment");
                }
                else
                {
                    Messages.InvalidInputMessage("Data");
                }
            }
            else
            {
                Messages.NotFoundMessage("Doctor");
            }
        }



        public void ViewAppointmentsOfDoctor()
        {
            Messages.InputMessage("Doctor");
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
                Messages.NotFoundMessage("Doctor");
            }
        }
    }
}
