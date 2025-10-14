using System;
using System.Collections.Generic;
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
        private readonly IEmailService _emailService;

        public PatientMenu(
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

        private void ViewAppointmentsByPatient()
        {
            Console.Clear();
            var doc = ConsoleInput.ReadNonEmpty("Enter your document: ");

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

        private void ScheduleAppointment()
        {
            Console.Clear();

            // 1) Identify patient
            var pDoc = ConsoleInput.ReadNonEmpty("Your document: ");
            var patient = _patientService.FindByDocument(pDoc);
            if (patient == null)
            {
                Console.WriteLine("Patient not found. Please register through Administration.");
                ConsoleInput.Pause();
                return;
            }

            // 2) Choose doctor (with optional specialty filter)
            var doctor = PickDoctor();
            if (doctor == null)
            {
                // User cancelled or list empty
                ConsoleInput.Pause();
                return;
            }

            // 3) Pick date time
            var start = ConsoleInput.ReadDateTime("Date and time", "yyyy-MM-dd HH:mm");

            // 4) Build appointment
            var appt = new Appointment
            {
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                Patient = patient,
                Doctor = doctor,
                StartTime = start
            };

            // 5) Schedule
            var ok = _appointmentService.ScheduleAppointment(appt);
            if (!ok)
            {
                Console.WriteLine("Scheduling failed.");
                ConsoleInput.Pause();
                return;
            }

            // 6) Email simulation
            var sent = _emailService.SendAppointmentConfirmation(appt, out var error);
            if (sent)
                Console.WriteLine($"Appointment scheduled successfully. A confirmation email was sent to {patient.Email}");
            else
                Console.WriteLine($"Appointment scheduled but email could not be sent. Error: {error}");

            ConsoleInput.Pause();
        }

        /// <summary>
        /// Let the patient browse doctors, optionally filter by specialty, and pick one by index.
        /// Returns null if the list is empty or the user cancels.
        /// </summary>
        private Doctor? PickDoctor()
        {
            // Ask if the patient wants to filter by specialty
            Console.Write("Filter by specialty? (y/n): ");
            var f = Console.ReadLine()?.Trim().ToLowerInvariant();
            List<Doctor> doctors;

            if (f == "y" || f == "yes")
            {
                var specialty = ConsoleInput.ReadNonEmpty("Enter specialty: ");
                doctors = _doctorService.GetDoctorsBySpecialty(specialty);
            }
            else
            {
                doctors = _doctorService.GetAllDoctors();
            }

            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors available with the selected criteria.");
                return null;
            }

            Console.WriteLine();
            Console.WriteLine("Select a doctor:");
            for (int i = 0; i < doctors.Count; i++)
            {
                var d = doctors[i];
                Console.WriteLine($"{i + 1}. {d.Name} | {d.Specialty} | Doc: {d.Document} | Phone: {d.Phone}");
            }
            Console.WriteLine("0. Cancel");

            var choice = ConsoleInput.ReadInt("Option: ", 0, doctors.Count);
            if (choice == 0) return null;

            return doctors[choice - 1];
        }
    }
}
