using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    // Base class with common person properties
    public abstract class Person
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Document { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;
    }
}