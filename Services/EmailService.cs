using System;
using System.Collections.Generic;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Services
{
    // Simulated email sender with in-memory log
    public class EmailService : IEmailService
    {
        private readonly List<EmailLog> _logs = new();

        public bool SendAppointmentConfirmation(Appointment appointment, out string error)
        {
            try
            {
                // Simulate success (you could add random failures for demo)
                var log = new EmailLog
                {
                    ToEmail = appointment.Patient?.Email ?? "unknown@domain.com",
                    Subject = "Appointment Confirmation",
                    BodySnippet = $"Appointment on {appointment.StartTime:yyyy-MM-dd HH:mm}",
                    Status = "Sent",
                    AppointmentId = appointment.Id
                };
                _logs.Add(log);
                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                _logs.Add(new EmailLog
                {
                    ToEmail = appointment.Patient?.Email ?? "",
                    Subject = "Appointment Confirmation",
                    BodySnippet = "N/A",
                    Status = "Not Sent",
                    Error = ex.Message,
                    AppointmentId = appointment.Id
                });
                error = ex.Message;
                return false;
            }
        }

        public List<EmailLog> GetLogs() => _logs;
    }
}