using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Seeder
{
    public static class PatientSeeder
    {
        public static void Seed(IPatientService patientService)
        {
            patientService.RegisterPatient(new Patient
            {
                Name = "John Doe",
                Document = "P001",
                Age = 30,
                Phone = "123456789",
                Email = "john.doe@email.com"
            });

            patientService.RegisterPatient(new Patient
            {
                Name = "Jane Smith",
                Document = "P002",
                Age = 28,
                Phone = "987654321",
                Email = "jane.smith@email.com"
            });
        }
    }
}