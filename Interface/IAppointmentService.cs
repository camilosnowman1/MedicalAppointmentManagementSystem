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
        List<Appointment> GetAppointmentsByPatient(string patientDocument);
        List<Appointment> GetAppointmentsByDoctor(string doctorDocument);
    }
}