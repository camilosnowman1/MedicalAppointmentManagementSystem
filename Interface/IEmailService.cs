using System.Collections.Generic;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Interface
{
    // Email sending and logging abstraction
    public interface IEmailService
    {
        bool SendAppointmentConfirmation(Appointment appointment, out string error);
        List<EmailLog> GetLogs();
    }
}