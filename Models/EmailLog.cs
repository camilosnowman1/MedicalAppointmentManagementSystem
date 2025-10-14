using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    public class EmailLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string ToEmail { get; set; }

        [MaxLength(200)]
        public string Subject { get; set; }

        [MaxLength(300)]
        public string BodySnippet { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Not Sent";

        public string Error { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}