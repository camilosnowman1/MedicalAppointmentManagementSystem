using System.Collections.Generic;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Interface
{
    public interface IDoctorService
    {
        bool RegisterDoctor(Doctor doctor);
        bool EditDoctor(string document, Doctor updatedDoctor);
        Doctor? FindByDocument(string document);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetDoctorsBySpecialty(string specialty);
    }
}