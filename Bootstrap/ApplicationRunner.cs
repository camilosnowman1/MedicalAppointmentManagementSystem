using System;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Utils.Menu;

namespace MedicalAppointmentApp.Bootstrap
{
    public class ApplicationRunner
    {
        private readonly AdminMenu _adminMenu;
        private readonly DoctorMenu _doctorMenu;
        private readonly PatientMenu _patientMenu;

        public ApplicationRunner(IPatientService patientService, IDoctorService doctorService, IAppointmentService appointmentService, IEmailService emailService)
        {
            _adminMenu = new AdminMenu(patientService, doctorService, appointmentService, emailService);
            _doctorMenu = new DoctorMenu(appointmentService);
            _patientMenu = new PatientMenu(patientService, doctorService, appointmentService);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Medical Appointment System ====");
                Console.WriteLine("Select your role:");
                Console.WriteLine("1. Administrator");
                Console.WriteLine("2. Doctor");
                Console.WriteLine("3. Patient");
                Console.WriteLine("0. Exit");
                Console.Write("Option: ");
                var op = Console.ReadLine();

                switch (op)
                {
                    case "1": _adminMenu.Show(); break;
                    case "2": _doctorMenu.Show(); break;
                    case "3": _patientMenu.Show(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}