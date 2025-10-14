using MedicalAppointmentApp.Bootstrap;
using MedicalAppointmentApp.Seeder;

namespace MedicalAppointmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize services
            var (patientService, doctorService, appointmentService, emailService) = ApplicationInitializer.Initialize();

            // Seed demo data before running the application
            DataSeeder.Seed(patientService, doctorService, appointmentService);

            // Start the application
            var app = new ApplicationRunner(patientService, doctorService, appointmentService, emailService);
            app.Run();
        }
    }
}