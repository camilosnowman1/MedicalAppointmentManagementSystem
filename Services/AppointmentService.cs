using System;
using System.Collections.Generic;
using System.Linq;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly List<Appointment> _appointments = new();
        private readonly Dictionary<Guid, Appointment> _byId = new();
        private readonly IEmailService _emailService;

        public AppointmentService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            try
            {
                if (appointment.PatientId == Guid.Empty || appointment.DoctorId == Guid.Empty)
                {
                    Console.WriteLine("Error: Appointment must have a valid patient and doctor.");
                    return false;
                }
                if (appointment.StartTime <= DateTime.Now)
                {
                    Console.WriteLine("Error: Appointment date must be in the future.");
                    return false;
                }
                if (_appointments.Any(a => a.DoctorId == appointment.DoctorId && a.StartTime == appointment.StartTime))
                {
                    Console.WriteLine("Error: This doctor already has an appointment at this time.");
                    return false;
                }
                if (_appointments.Any(a => a.PatientId == appointment.PatientId && a.StartTime == appointment.StartTime))
                {
                    Console.WriteLine("Error: This patient already has an appointment at this time.");
                    return false;
                }

                appointment.Id = Guid.NewGuid();
                appointment.Status = "Scheduled";
                _appointments.Add(appointment);
                _byId[appointment.Id] = appointment;

                // Send confirmation email and log result
                _emailService.SendAppointmentConfirmation(appointment, out var err);
                if (!string.IsNullOrEmpty(err))
                    Console.WriteLine($"Warning: Email not sent. Reason: {err}");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while scheduling appointment: {ex.Message}");
                return false;
            }
        }

        public bool CancelAppointment(Guid id)
        {
            try
            {
                if (!_byId.TryGetValue(id, out var appt))
                {
                    Console.WriteLine("Error: Appointment not found.");
                    return false;
                }
                appt.Status = "Cancelled";
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while cancelling appointment: {ex.Message}");
                return false;
            }
        }

        public bool MarkAsAttended(Guid id)
        {
            try
            {
                if (!_byId.TryGetValue(id, out var appt))
                {
                    Console.WriteLine("Error: Appointment not found.");
                    return false;
                }
                appt.Status = "Attended";
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while marking appointment: {ex.Message}");
                return false;
            }
        }

        public List<Appointment> GetAppointmentsByPatient(string patientDocument)
            => _appointments.Where(a => a.Patient?.Document == patientDocument).ToList();

        public List<Appointment> GetAppointmentsByDoctor(string doctorDocument)
            => _appointments.Where(a => a.Doctor?.Document == doctorDocument).ToList();
    }
}
