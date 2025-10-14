using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    // Patient inherits from Person
    public class Patient : Person
    {
        [Range(0, 120)]
        public int Age { get; set; }
    }
}