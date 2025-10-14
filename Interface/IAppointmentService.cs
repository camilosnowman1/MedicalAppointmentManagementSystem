using System;
using System.Collections.Generic;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Interface
{
    public interface IAppointmentService
    {
        bool ScheduleAppointment(Appointment appointment);
        bool CancelAppointment(Guid id);
        bool MarkAsAttended(Guid id);

        // New methods added for DoctorMenu and better control
        Appointment? FindAppointmentById(Guid id); // Find appointment by ID
        bool UpdateAppointmentStatus(Guid id, AppointmentStatus status); // Update appointment status

        List<Appointment> GetAppointmentsByPatient(string patientDocument);
        List<Appointment> GetAppointmentsByDoctor(string doctorDocument);
    }
}