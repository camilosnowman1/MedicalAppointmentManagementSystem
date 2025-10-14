using System;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;
using MedicalAppointmentApp.Utils;

namespace MedicalAppointmentApp.Utils.Menu
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public PatientMenu(IPatientService patientService, IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Patient Menu ===");
                Console.WriteLine("1. View my appointments");
                Console.WriteLine("2. Schedule appointment");
                Console.WriteLine("0. Back");
                Console.Write("Option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ViewAppointmentsByPatient();
                        break;
                    case "2":
                        ScheduleAppointment();
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

        // View all appointments for a patient
        private void ViewAppointmentsByPatient()
        {
            Console.Clear();
            var doc = ConsoleInput.ReadNonEmpty("Enter your document: ");

            if (string.IsNullOrWhiteSpace(doc))
            {
                Console.WriteLine("Document cannot be empty.");
                Console.ReadKey();
                return;
            }

            var list = _appointmentService.GetAppointmentsByPatient(doc);

            if (list.Count == 0)
            {
                Console.WriteLine("No appointments found for this patient.");
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

        // Schedule a new appointment
        private void ScheduleAppointment()
        {
            Console.Clear();

            // Input validation
            var pDoc = ConsoleInput.ReadNonEmpty("Patient document: ");
            var dDoc = ConsoleInput.ReadNonEmpty("Doctor document: ");
            var start = ConsoleInput.ReadDateTime("Date and time", "yyyy-MM-dd HH:mm");

            var patient = _patientService.FindByDocument(pDoc);
            if (patient == null)
            {
                Console.WriteLine("Patient not found. Please verify the document.");
                ConsoleInput.Pause();
                return;
            }

            var doctor = _doctorService.FindByDocument(dDoc);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found. Please verify the document.");
                ConsoleInput.Pause();
                return;
            }

            // Create appointment object
            var appointment = new Appointment
            {
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                Patient = patient,
                Doctor = doctor,
                StartTime = start
            };

            var success = _appointmentService.ScheduleAppointment(appointment);

            Console.WriteLine(success
                ? "Appointment scheduled successfully."
                : "Failed to schedule appointment. Please try again.");

            ConsoleInput.Pause();
        }
    }
}
