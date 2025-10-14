using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Seeder
{
    public static class DoctorSeeder
    {
        public static void Seed(IDoctorService doctorService)
        {
            doctorService.RegisterDoctor(new Doctor
            {
                Name = "Dr. Emily Brown",
                Document = "D001",
                Specialty = "Cardiology",
                Phone = "111222333",
                Email = "emily.brown@hospital.com"
            });

            doctorService.RegisterDoctor(new Doctor
            {
                Name = "Dr. Robert Johnson",
                Document = "D002",
                Specialty = "Dermatology",
                Phone = "444555666",
                Email = "robert.johnson@hospital.com"
            });
        }
    }
}