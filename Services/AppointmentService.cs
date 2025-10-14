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

        // Schedule a new appointment with validation and email simulation
        public bool ScheduleAppointment(Appointment appointment)
        {
            try
            {
                // Validation rules
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

                // Create and store appointment
                appointment.Id = Guid.NewGuid();
                appointment.Status = AppointmentStatus.Scheduled;
                _appointments.Add(appointment);
                _byId[appointment.Id] = appointment;

                // Send confirmation email simulation
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

        // Cancel an existing appointment
        public bool CancelAppointment(Guid id)
        {
            try
            {
                if (!_byId.TryGetValue(id, out var appt))
                {
                    Console.WriteLine("Error: Appointment not found.");
                    return false;
                }

                appt.Status = AppointmentStatus.Cancelled;

                // Simulate email notification for cancellation
                _emailService.SendAppointmentConfirmation(appt, out var err);
                if (!string.IsNullOrEmpty(err))
                    Console.WriteLine($"Warning: Cancellation email not sent. Reason: {err}");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while cancelling appointment: {ex.Message}");
                return false;
            }
        }

        // Mark an appointment as attended
        public bool MarkAsAttended(Guid id)
        {
            try
            {
                if (!_byId.TryGetValue(id, out var appt))
                {
                    Console.WriteLine("Error: Appointment not found.");
                    return false;
                }

                appt.Status = AppointmentStatus.Attended;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while marking appointment as attended: {ex.Message}");
                return false;
            }
        }

        // Get appointment by ID
        public Appointment? FindAppointmentById(Guid id)
        {
            _byId.TryGetValue(id, out var appt);
            return appt;
        }

        // Update appointment status manually
        public bool UpdateAppointmentStatus(Guid id, AppointmentStatus status)
        {
            if (!_byId.TryGetValue(id, out var appt))
            {
                Console.WriteLine("Error: Appointment not found.");
                return false;
            }

            appt.Status = status;
            return true;
        }

        // Retrieve appointments by patient document
        public List<Appointment> GetAppointmentsByPatient(string patientDocument)
            => _appointments.Where(a => a.Patient?.Document == patientDocument).ToList();

        // Retrieve appointments by doctor document
        public List<Appointment> GetAppointmentsByDoctor(string doctorDocument)
            => _appointments.Where(a => a.Doctor?.Document == doctorDocument).ToList();
    }
}
