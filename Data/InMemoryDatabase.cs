using System.Collections.Generic;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Data
{
    // This static class simulates a database using in-memory lists.
    public static class InMemoryDatabase
    {
        // List of patients
        public static List<Patient> Patients { get; } = new List<Patient>();

        // List of doctors
        public static List<Doctor> Doctors { get; } = new List<Doctor>();

        // List of appointments
        public static List<Appointment> Appointments { get; } = new List<Appointment>();

        // List of email logs
        public static List<EmailLog> EmailLogs { get; } = new List<EmailLog>();
    }
}