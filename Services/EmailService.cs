using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly List<EmailLog> _logs = new();

        // Send appointment confirmation email
        public bool SendAppointmentConfirmation(Appointment appointment, out string error)
        {
            try
            {
                // Build the email content
                string subject = "Appointment Confirmation";
                string body = $"Hello {appointment.Patient?.Name},\n\n" +
                              $"Your appointment is scheduled on {appointment.StartTime:yyyy-MM-dd HH:mm} with Dr. {appointment.Doctor?.Name}.\n\n" +
                              $"Thank you for using our system.";

                SendEmail(appointment.Patient?.Email, subject, body);
                _logs.Add(new EmailLog
                {
                    ToEmail = appointment.Patient?.Email ?? "",
                    Subject = subject,
                    BodySnippet = body,
                    Status = "Sent",
                    AppointmentId = appointment.Id
                });

                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                _logs.Add(new EmailLog
                {
                    ToEmail = appointment.Patient?.Email ?? "",
                    Subject = "Appointment Confirmation",
                    BodySnippet = "N/A",
                    Status = "Not Sent",
                    Error = ex.Message,
                    AppointmentId = appointment.Id
                });
                return false;
            }
        }

        // Send appointment cancellation email
        public bool SendAppointmentCancellation(Appointment appointment, out string error)
        {
            try
            {
                string subject = "Appointment Cancellation Notice";
                string body = $"Hello {appointment.Patient?.Name},\n\n" +
                              $"Your appointment scheduled on {appointment.StartTime:yyyy-MM-dd HH:mm} has been cancelled.\n\n" +
                              $"If this is a mistake, please contact us.";

                SendEmail(appointment.Patient?.Email, subject, body);
                _logs.Add(new EmailLog
                {
                    ToEmail = appointment.Patient?.Email ?? "",
                    Subject = subject,
                    BodySnippet = body,
                    Status = "Sent",
                    AppointmentId = appointment.Id
                });

                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                _logs.Add(new EmailLog
                {
                    ToEmail = appointment.Patient?.Email ?? "",
                    Subject = "Appointment Cancellation",
                    BodySnippet = "N/A",
                    Status = "Not Sent",
                    Error = ex.Message,
                    AppointmentId = appointment.Id
                });
                return false;
            }
        }

        // Return all email logs
        public List<EmailLog> GetLogs() => _logs;

        // Method to send the email using Gmail SMTP
        private void SendEmail(string to, string subject, string body)
        {
            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("camilosnow1997@gmail.com", "sgknremzvzrhxvdi"), // ✅ App password without spaces
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress("camilosnow1997@gmail.com", "MedicalAppointmentSystem"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            mail.To.Add(to);
            client.Send(mail);
        }
    }
}
