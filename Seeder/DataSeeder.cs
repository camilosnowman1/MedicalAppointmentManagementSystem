using MedicalAppointmentApp.Interface;

namespace MedicalAppointmentApp.Seeder
{
    public static class DataSeeder
    {
        public static void Seed(
            IPatientService patientService,
            IDoctorService doctorService,
            IAppointmentService appointmentService)
        {
            PatientSeeder.Seed(patientService);
            DoctorSeeder.Seed(doctorService);
            AppointmentSeeder.Seed(patientService, doctorService, appointmentService);

            Console.WriteLine("✅ Demo data seeded successfully!");
        }
    }
}