using System;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Utils.Menu;

namespace MedicalAppointmentApp.Utils
{
    // Main system menu - Entry point for selecting user role
    public class MainMenu
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IEmailService _emailService;

        public MainMenu(
            IPatientService patientService,
            IDoctorService doctorService,
            IAppointmentService appointmentService,
            IEmailService emailService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _emailService = emailService;
        }

        public void Start()
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

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        new AdminMenu(_patientService, _doctorService, _appointmentService, _emailService).Show();
                        break;
                    case "2":
                        new DoctorMenu(_appointmentService).Show();
                        break;
                    case "3":
                        // Fixed: pass emailService to PatientMenu
                        new PatientMenu(_patientService, _doctorService, _appointmentService, _emailService).Show();
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
