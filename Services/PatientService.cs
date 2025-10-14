using System;
using System.Collections.Generic;
using System.Linq;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly List<Patient> _patients = new();
        private readonly Dictionary<string, Patient> _byDocument = new();

        public bool RegisterPatient(Patient patient)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(patient.Name) ||
                    string.IsNullOrWhiteSpace(patient.Document) ||
                    string.IsNullOrWhiteSpace(patient.Email))
                {
                    Console.WriteLine("Error: All fields are required.");
                    return false;
                }
                if (patient.Age <= 0 || patient.Age > 120)
                {
                    Console.WriteLine("Error: Age must be between 1 and 120.");
                    return false;
                }
                if (!patient.Email.Contains("@") || !patient.Email.Contains("."))
                {
                    Console.WriteLine("Error: Invalid email format.");
                    return false;
                }
                if (_byDocument.ContainsKey(patient.Document))
                {
                    Console.WriteLine("Error: A patient with this document already exists.");
                    return false;
                }

                patient.Id = Guid.NewGuid();
                _patients.Add(patient);
                _byDocument[patient.Document] = patient;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while registering patient: {ex.Message}");
                return false;
            }
        }

        public bool EditPatient(string document, Patient updatedPatient)
        {
            try
            {
                if (!_byDocument.TryGetValue(document, out var existing))
                {
                    Console.WriteLine("Error: Patient not found.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(updatedPatient.Name) ||
                    string.IsNullOrWhiteSpace(updatedPatient.Email))
                {
                    Console.WriteLine("Error: Name and Email are required.");
                    return false;
                }
                if (updatedPatient.Age <= 0 || updatedPatient.Age > 120)
                {
                    Console.WriteLine("Error: Age must be between 1 and 120.");
                    return false;
                }

                existing.Name = updatedPatient.Name;
                existing.Age = updatedPatient.Age;
                existing.Phone = updatedPatient.Phone;
                existing.Email = updatedPatient.Email;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while editing patient: {ex.Message}");
                return false;
            }
        }

        public Patient? FindByDocument(string document)
        {
            try
            {
                return _byDocument.TryGetValue(document, out var p) ? p : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while searching patient: {ex.Message}");
                return null;
            }
        }

        public List<Patient> GetAllPatients() => _patients;
    }
}
