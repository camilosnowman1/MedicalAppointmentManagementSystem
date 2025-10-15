# 🏥 Medical Appointment Management System

## 📚 Table of Contents
- [Project Overview](#-project-overview)
- [Objectives](#-objectives)
- [Main Features](#-main-features)
- [Data Persistence](#-data-persistence)
- [Technologies Used](#-technologies-used)
- [Project Structure](#-project-structure)
- [Prerequisites](#-prerequisites)
- [Installation & Execution](#-installation--execution)
- [Example Usage](#-example-usage)
- [Demo Data](#-demo-data-seeder)
- [UML Class Diagram](#-uml-class-diagram)
- [Use Cases](#-use-cases)
- [Author](#-author)
- [License](#-license)

---

## 📌 Project Overview

**Medical Appointment Management System** is a console-based application developed in **C#** that allows *Hospital San Vicente* to digitalize and optimize the management of medical appointments, patients, and doctors.  
The system centralizes all data, automates appointment scheduling, and ensures data integrity, consistency, and accessibility.

---

## 🎯 Objectives

- Eliminate the use of paper agendas and spreadsheets.
- Prevent duplicate appointments for the same patient or doctor.
- Facilitate the registration, management, and search of patients and doctors.
- Automate appointment confirmation via email.
- Maintain a complete history of appointments and email notifications.

---

## ⚙️ Main Features

### 👤 Patient Management
- Register new patients.
- Edit existing patient information.
- Validate duplicate patients by ID/document.
- List all registered patients.

### 🩺 Doctor Management
- Register new doctors.
- Edit doctor information.
- Validate duplicate doctors by ID/document.
- List all doctors and filter by specialty.

### 📅 Appointment Management
- Schedule appointments with validation of doctor and patient availability.
- Cancel appointments and change status to **Cancelled**.
- Mark appointments as **Attended**.
- List appointments by patient or doctor.
- Automatically send confirmation emails when an appointment is created.
- Keep a complete log of sent emails.

---

## 🗂️ Data Persistence

- Managed using **List<>**, **Dictionary<,>**, and **LINQ**.
- Ready for future database integration (e.g., **Entity Framework Core**, **MySQL**, **PostgreSQL**).

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET 8.0
- **ORM (Optional):** Entity Framework Core
- **Data Structures:** List, Dictionary, LINQ
- **Email:** MailKit / SMTP
- **Recommended IDE:** JetBrains Rider / Visual Studio

---

## 📁 Project Structure

MedicalAppointmentManagementSystem/
│
├─ Models/ # Domain classes (Patient, Doctor, Appointment, etc.)
├─ Services/ # Business logic (PatientService, DoctorService, AppointmentService)
├─ Interface/ # Interfaces for dependency injection
├─ Utils/ # Utilities (ConsoleInput, validation, menus)
├─ Seeder/ # Demo seed data
├─ Bootstrap/ # App initialization and configuration
├─ Program.cs # Application entry point
└─ README.md # Project documentation


---

## 🖥️ Prerequisites

- .NET SDK 8.0 or higher
- Visual Studio / Rider / VS Code
- (Optional) Configured SMTP server for email sending

---

## 🚀 Installation & Execution

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/MedicalAppointmentManagementSystem.git
Navigate to the project directory:

cd MedicalAppointmentManagementSystem/MedicalAppointmentApp


Restore dependencies:

dotnet restore


Build the project:

dotnet build


Run the application:

dotnet run

📸 Example Usage
==== Medical Appointment System ====
Select your role:
1. Administrator
2. Doctor
3. Patient
0. Exit
   Option: