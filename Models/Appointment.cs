using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        // Use enum instead of string for better consistency and validation
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}