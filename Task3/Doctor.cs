using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Doctor
    {
        public string Name { get; set; }

        public List<Appointment> Appointments{ get; set; }

        public Doctor(string name)
        {
            Name = name;
            Appointments = new List<Appointment>();
        }

        public void ScheduleAppointment(string patientName, DateTime date)
        {
            Appointment appointment = new Appointment(patientName, date);
            Appointments.Add(appointment);
            Messages.InputMessage("Patientname");
        }

    }
}
