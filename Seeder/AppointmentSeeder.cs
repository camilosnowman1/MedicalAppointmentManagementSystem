using System;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Seeder
{
    public static class AppointmentSeeder
    {
        public static void Seed(
            IPatientService patientService,
            IDoctorService doctorService,
            IAppointmentService appointmentService)
        {
            var patient1 = patientService.FindByDocument("P001");
            var doctor1 = doctorService.FindByDocument("D001");

            if (patient1 != null && doctor1 != null)
            {
                appointmentService.ScheduleAppointment(new Appointment
                {
                    PatientId = patient1.Id,
                    DoctorId = doctor1.Id,
                    Patient = patient1,
                    Doctor = doctor1,
                    StartTime = DateTime.Now.AddDays(1)
                });
            }

            var patient2 = patientService.FindByDocument("P002");
            var doctor2 = doctorService.FindByDocument("D002");

            if (patient2 != null && doctor2 != null)
            {
                appointmentService.ScheduleAppointment(new Appointment
                {
                    PatientId = patient2.Id,
                    DoctorId = doctor2.Id,
                    Patient = patient2,
                    Doctor = doctor2,
                    StartTime = DateTime.Now.AddDays(2)
                });
            }
        }
    }
}