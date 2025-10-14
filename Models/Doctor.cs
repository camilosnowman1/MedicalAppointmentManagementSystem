using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    public class Doctor : Person
    {
        [Required, MaxLength(50)]
        public string Specialty { get; set; }
    }
}