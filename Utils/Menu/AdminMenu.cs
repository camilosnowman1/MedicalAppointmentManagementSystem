using System;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Utils.Menu
{
    public class AdminMenu
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IEmailService _emailService;

        public AdminMenu(IPatientService patientService, IDoctorService doctorService,
                         IAppointmentService appointmentService, IEmailService emailService)
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
                Console.WriteLine("=== Administrator Menu ===");
                Console.WriteLine("1. Register patient");
                Console.WriteLine("2. Edit patient");
                Console.WriteLine("3. Register doctor");
                Console.WriteLine("4. Edit doctor");
                Console.WriteLine("5. List patients");
                Console.WriteLine("6. List doctors (by specialty)");
                Console.WriteLine("7. Schedule appointment");
                Console.WriteLine("8. Cancel appointment");
                Console.WriteLine("9. View email logs");
                Console.WriteLine("0. Back");
                Console.Write("Option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1": RegisterPatient(); break;
                    case "2": EditPatient(); break;
                    case "3": RegisterDoctor(); break;
                    case "4": EditDoctor(); break;
                    case "5": ListPatients(); break;
                    case "6": ListDoctorsBySpecialty(); break;
                    case "7": Schedule(); break;
                    case "8": Cancel(); break;
                    case "9": ShowEmailLogs(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid option.");
                        ConsoleInput.Pause();
                        break;
                }
            }
        }

        private void RegisterPatient()
        {
            Console.Clear();
            var p = new Patient
            {
                Name = ConsoleInput.ReadNonEmpty("Name: "),
                Document = ConsoleInput.ReadNonEmpty("Document: "),
                Age = ConsoleInput.ReadInt("Age: ", 1, 120),
                Phone = ConsoleInput.ReadNonEmpty("Phone: "),
                Email = ConsoleInput.ReadNonEmpty("Email: ")
            };
            Console.WriteLine(_patientService.RegisterPatient(p) ? "Patient registered." : "Operation failed.");
            ConsoleInput.Pause();
        }

        private void EditPatient()
        {
            Console.Clear();
            var doc = ConsoleInput.ReadNonEmpty("Patient document to edit: ");
            var updated = new Patient
            {
                Name = ConsoleInput.ReadNonEmpty("New name: "),
                Age = ConsoleInput.ReadInt("New age: ", 1, 120),
                Phone = ConsoleInput.ReadNonEmpty("New phone: "),
                Email = ConsoleInput.ReadNonEmpty("New email: ")
            };
            Console.WriteLine(_patientService.EditPatient(doc, updated) ? "Patient updated." : "Operation failed.");
            ConsoleInput.Pause();
        }

        private void RegisterDoctor()
        {
            Console.Clear();
            var d = new Doctor
            {
                Name = ConsoleInput.ReadNonEmpty("Name: "),
                Document = ConsoleInput.ReadNonEmpty("Document: "),
                Specialty = ConsoleInput.ReadNonEmpty("Specialty: "),
                Phone = ConsoleInput.ReadNonEmpty("Phone: "),
                Email = ConsoleInput.ReadNonEmpty("Email: ")
            };
            Console.WriteLine(_doctorService.RegisterDoctor(d) ? "Doctor registered." : "Operation failed.");
            ConsoleInput.Pause();
        }

        private void EditDoctor()
        {
            Console.Clear();
            var doc = ConsoleInput.ReadNonEmpty("Doctor document to edit: ");
            var updated = new Doctor
            {
                Name = ConsoleInput.ReadNonEmpty("New name: "),
                Specialty = ConsoleInput.ReadNonEmpty("New specialty: "),
                Phone = ConsoleInput.ReadNonEmpty("New phone: "),
                Email = ConsoleInput.ReadNonEmpty("New email: ")
            };
            Console.WriteLine(_doctorService.EditDoctor(doc, updated) ? "Doctor updated." : "Operation failed.");
            ConsoleInput.Pause();
        }

        private void ListPatients()
        {
            Console.Clear();
            var list = _patientService.GetAllPatients();
            if (list.Count == 0) 
                Console.WriteLine("No patients.");
            else 
                foreach (var p in list) 
                    Console.WriteLine($"{p.Document} - {p.Name} - {p.Email}");
            ConsoleInput.Pause();
        }

        private void ListDoctorsBySpecialty()
        {
            Console.Clear();
            var spec = ConsoleInput.ReadNonEmpty("Specialty to filter: ");
            var list = _doctorService.GetDoctorsBySpecialty(spec);
            if (list.Count == 0) 
                Console.WriteLine("No doctors found.");
            else 
                foreach (var d in list) 
                    Console.WriteLine($"{d.Document} - {d.Name} - {d.Specialty}");
            ConsoleInput.Pause();
        }

        private void Schedule()
        {
            Console.Clear();
            var pDoc = ConsoleInput.ReadNonEmpty("Patient document: ");
            var dDoc = ConsoleInput.ReadNonEmpty("Doctor document: ");
            var start = ConsoleInput.ReadDateTime("Date and time", "yyyy-MM-dd HH:mm");

            var patient = _patientService.FindByDocument(pDoc);
            var doctor = _doctorService.FindByDocument(dDoc);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                ConsoleInput.Pause();
                return;
            }
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                ConsoleInput.Pause();
                return;
            }

            var appt = new Appointment
            {
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                Patient = patient,
                Doctor = doctor,
                StartTime = start
            };

            var ok = _appointmentService.ScheduleAppointment(appt);
            Console.WriteLine(ok ? "Appointment scheduled (email logged)." : "Scheduling failed.");
            ConsoleInput.Pause();
        }

        private void Cancel()
        {
            Console.Clear();
            var id = ConsoleInput.ReadGuid("Appointment ID (GUID): ");
            var ok = _appointmentService.CancelAppointment(id);
            Console.WriteLine(ok ? "Appointment cancelled." : "Operation failed.");
            ConsoleInput.Pause();
        }

        private void ShowEmailLogs()
        {
            Console.Clear();
            var logs = _emailService.GetLogs();
            if (logs.Count == 0) 
                Console.WriteLine("No email logs.");
            else
                foreach (var l in logs)
                    Console.WriteLine($"{l.CreatedAtUtc:u} | {l.ToEmail} | {l.Subject} | {l.Status} | Appt: {l.AppointmentId}");
            ConsoleInput.Pause();
        }
    }
}
