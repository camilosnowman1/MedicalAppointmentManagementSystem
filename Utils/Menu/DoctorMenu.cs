using System;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;
using MedicalAppointmentApp.Utils;

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
                Console.WriteLine("1. View all appointments");
                Console.WriteLine("2. Mark appointment as attended");
                Console.WriteLine("3. View pending appointments");
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
                    case "3":
                        ViewPendingAppointments();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        ConsoleInput.Pause();
                        break;
                }
            }
        }

        // Display all appointments for a specific doctor
        private void ViewAppointmentsByDoctor()
        {
            Console.Clear();
            var doc = ConsoleInput.ReadNonEmpty("Enter doctor document: ");
            var list = _appointmentService.GetAppointmentsByDoctor(doc);

            if (list.Count == 0)
            {
                Console.WriteLine("No appointments found.");
            }
            else
            {
                foreach (var a in list)
                {
                    Console.WriteLine($"ID: {a.Id} | Date: {a.StartTime} | Status: {a.Status}");
                }
            }
            ConsoleInput.Pause();
        }

        // Mark an appointment as attended
        private void MarkAppointmentAsAttended()
        {
            Console.Clear();
            var id = ConsoleInput.ReadGuid("Enter Appointment ID (GUID): ");

            var appointment = _appointmentService.FindAppointmentById(id);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                ConsoleInput.Pause();
                return;
            }

            if (appointment.Status == AppointmentStatus.Cancelled)
            {
                Console.WriteLine("This appointment was cancelled and cannot be marked as attended.");
                ConsoleInput.Pause();
                return;
            }

            appointment.Status = AppointmentStatus.Attended;
            var ok = _appointmentService.UpdateAppointmentStatus(appointment.Id, AppointmentStatus.Attended);

            Console.WriteLine(ok ? "Appointment marked as attended." : "Operation failed.");
            ConsoleInput.Pause();
        }

        // Show only pending (scheduled) appointments
        private void ViewPendingAppointments()
        {
            Console.Clear();
            var doc = ConsoleInput.ReadNonEmpty("Enter doctor document: ");
            var list = _appointmentService.GetAppointmentsByDoctor(doc);

            var pending = list.FindAll(a => a.Status == AppointmentStatus.Scheduled);

            if (pending.Count == 0)
            {
                Console.WriteLine("No pending appointments.");
            }
            else
            {
                Console.WriteLine("=== Pending Appointments ===");
                foreach (var a in pending)
                {
                    Console.WriteLine($"ID: {a.Id} | Date: {a.StartTime} | Status: {a.Status}");
                }
            }
            ConsoleInput.Pause();
        }
    }
}
