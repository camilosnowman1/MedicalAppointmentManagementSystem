using System;
using System.Collections.Generic;
using System.Linq;
using MedicalAppointmentApp.Interface;
using MedicalAppointmentApp.Models;

namespace MedicalAppointmentApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly List<Doctor> _doctors = new();
        private readonly Dictionary<string, Doctor> _byDocument = new();

        public bool RegisterDoctor(Doctor doctor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(doctor.Name) ||
                    string.IsNullOrWhiteSpace(doctor.Document) ||
                    string.IsNullOrWhiteSpace(doctor.Specialty))
                {
                    Console.WriteLine("Error: All fields are required.");
                    return false;
                }
                if (!doctor.Email.Contains("@") || !doctor.Email.Contains("."))
                {
                    Console.WriteLine("Error: Invalid email format.");
                    return false;
                }
                if (_byDocument.ContainsKey(doctor.Document))
                {
                    Console.WriteLine("Error: A doctor with this document already exists.");
                    return false;
                }
                if (_doctors.Any(d =>
                        d.Name.Equals(doctor.Name, StringComparison.OrdinalIgnoreCase) &&
                        d.Specialty.Equals(doctor.Specialty, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Error: A doctor with the same name and specialty already exists.");
                    return false;
                }

                doctor.Id = Guid.NewGuid();
                _doctors.Add(doctor);
                _byDocument[doctor.Document] = doctor;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while registering doctor: {ex.Message}");
                return false;
            }
        }

        public Doctor? FindByDocument(string document)
        {
            try
            {
                return _byDocument.TryGetValue(document, out var d) ? d : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while searching doctor: {ex.Message}");
                return null;
            }
        }

        public List<Doctor> GetAllDoctors() => _doctors;

        public bool EditDoctor(string document, Doctor updatedDoctor)
        {
            try
            {
                if (!_byDocument.TryGetValue(document, out var existing))
                {
                    Console.WriteLine("Error: Doctor not found.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(updatedDoctor.Name) ||
                    string.IsNullOrWhiteSpace(updatedDoctor.Specialty))
                {
                    Console.WriteLine("Error: Name and Specialty are required.");
                    return false;
                }
                // Validate duplicated name+specialty against others
                if (_doctors.Any(d => !ReferenceEquals(d, existing) &&
                        d.Name.Equals(updatedDoctor.Name, StringComparison.OrdinalIgnoreCase) &&
                        d.Specialty.Equals(updatedDoctor.Specialty, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Error: Another doctor with the same name and specialty already exists.");
                    return false;
                }

                existing.Name = updatedDoctor.Name;
                existing.Specialty = updatedDoctor.Specialty;
                existing.Email = updatedDoctor.Email;
                existing.Phone = updatedDoctor.Phone;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while editing doctor: {ex.Message}");
                return false;
            }
        }

        public List<Doctor> GetDoctorsBySpecialty(string specialty)
        {
            try
            {
                return _doctors
                    .Where(d => d.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while filtering doctors: {ex.Message}");
                return new List<Doctor>();
            }
        }
    }
}
