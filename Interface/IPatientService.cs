using System.Collections.Generic;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Interface
{
    public interface IPatientService
    {
        bool RegisterPatient(Patient patient);
        bool EditPatient(string document, Patient updatedPatient);
        Patient? FindByDocument(string document);
        List<Patient> GetAllPatients();
    }
}