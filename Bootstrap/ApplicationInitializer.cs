using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Services;
using MedicalAppointmentApp.Seeder;

namespace MedicalAppointmentApp.Bootstrap
{
    public static class ApplicationInitializer
    {
        public static (IPatientService, IDoctorService, IAppointmentService, IEmailService) Initialize()
        {
            IPatientService patientService = new PatientService();
            IDoctorService doctorService = new DoctorService();
            IEmailService emailService = new EmailService();
            IAppointmentService appointmentService = new AppointmentService(emailService);

            // Seed initial data
            DataSeeder.Seed(patientService, doctorService, appointmentService);

            return (patientService, doctorService, appointmentService, emailService);
        }
    }
}