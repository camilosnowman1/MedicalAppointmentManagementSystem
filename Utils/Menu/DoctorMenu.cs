using System;
using MedicalAppointmentApp.Interface;

namespace MedicalAppointmentApp.Utils.Menu
{
    public class DoctorMenu
    {
        private readonly IAppointmentService _appointmentService;

        public DoctorMenu(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Doctor Menu ===");
                Console.WriteLine("1. View appointments by doctor");
                Console.WriteLine("2. Mark appointment as attended");
                Console.WriteLine("0. Back");
                Console.Write("Option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ViewAppointmentsByDoctor();
                        break;
                    case "2":
                        MarkAppointmentAsAttended();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // View all appointments for a doctor based on their document number
        private void ViewAppointmentsByDoctor()
        {
            Console.Clear();
            Console.Write("Enter doctor document: ");
            var doc = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(doc))
            {
                Console.WriteLine("Document cannot be empty.");
                Console.ReadKey();
                return;
            }

            var list = _appointmentService.GetAppointmentsByDoctor(doc);

            if (list.Count == 0)
            {
                Console.WriteLine("No appointments found for this doctor.");
            }
            else
            {
                foreach (var a in list)
                {
                    Console.WriteLine($"ID: {a.Id} - Date: {a.StartTime} - Status: {a.Status}");
                }
            }
            Console.ReadKey();
        }

        // Mark an appointment as attended using its GUID
        private void MarkAppointmentAsAttended()
        {
            Console.Clear();
            Console.Write("Enter Appointment ID (GUID): ");
            var input = Console.ReadLine();

            if (!Guid.TryParse(input, out var id))
            {
                Console.WriteLine("Invalid GUID format.");
                Console.ReadKey();
                return;
            }

            var success = _appointmentService.MarkAsAttended(id);

            Console.WriteLine(success
                ? "Appointment marked as attended successfully."
                : "Operation failed. Appointment may not exist or is already attended.");

            Console.ReadKey();
        }
    }
}
