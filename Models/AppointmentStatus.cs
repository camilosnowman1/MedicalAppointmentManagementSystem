namespace MedicalAppointmentApp.Models
{
    // Enumeration for appointment status to avoid string errors and improve type safety
    public enum AppointmentStatus
    {
        Scheduled,   // The appointment is booked
        Cancelled,   // The appointment was cancelled
        Attended     // The appointment was attended
    }
}