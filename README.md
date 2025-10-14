# 🏥 Medical Appointment Management System

## 📌 Descripción general

**Medical Appointment Management System** es una aplicación de consola desarrollada en **C#** que permite al Hospital San Vicente digitalizar y optimizar la gestión de citas médicas, pacientes y médicos.  
El sistema centraliza toda la información, automatiza la programación de citas y garantiza la integridad, consistencia y accesibilidad de los datos.

---

## 🧠 Objetivos del sistema

- Eliminar el uso de agendas físicas y hojas de cálculo.
- Evitar la duplicidad de citas para el mismo paciente o médico.
- Facilitar la búsqueda y gestión de pacientes y médicos.
- Automatizar el envío de confirmaciones de citas por correo electrónico.
- Mantener un historial de citas y correos enviados.

---

## ⚙️ Funcionalidades principales

### 👩‍⚕️ Gestión de Pacientes
- Registrar nuevos pacientes.
- Editar la información de un paciente existente.
- Validar duplicados mediante documento.
- Listar todos los pacientes.

### 🩺 Gestión de Médicos
- Registrar nuevos médicos.
- Editar información de médicos.
- Validar duplicados por documento.
- Listar médicos y filtrar por especialidad.

### 📅 Gestión de Citas Médicas
- Agendar citas con validación de disponibilidad de médico y paciente.
- Cancelar citas y cambiar estado a “Cancelada”.
- Marcar citas como “Atendida”.
- Listar citas por paciente o médico.
- Enviar correo de confirmación al paciente automáticamente.
- Guardar historial de correos enviados.

### 🗂️ Persistencia de datos
- Datos gestionados mediante **List<>**, **Dictionary<,>**, **LINQ**.
- Soporte para integración con bases de datos en el futuro (EF Core).

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET 8.0
- **ORM:** (opcional) Entity Framework Core
- **Estructuras:** List, Dictionary, LINQ
- **Correo:** MailKit / SMTP
- **IDE recomendado:** JetBrains Rider o Visual Studio

---

## 📁 Estructura del proyecto

MedicalAppointmentManagementSystem/
│
├─ Models/ # Clases del dominio (Patient, Doctor, Appointment, etc.)
├─ Services/ # Lógica de negocio (PatientService, DoctorService, etc.)
├─ Interface/ # Interfaces para inyección de dependencias
├─ Utils/ # Utilidades (ConsoleInput, validaciones, menús)
├─ Seeder/ # Datos iniciales de prueba
├─ Bootstrap/ # Inicialización y configuración de la aplicación
├─ Program.cs # Punto de entrada de la aplicación
└─ README.md # Documentación del proyecto

yaml
Copiar código

---

## 🖥️ Requisitos previos

- .NET SDK 8.0 o superior
- Visual Studio / Rider / VS Code
- (Opcional) Servidor SMTP configurado para envío de correos

---

## 🚀 Instrucciones de instalación y ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/tuusuario/MedicalAppointmentManagementSystem.git
Entrar al proyecto:

bash
Copiar código
cd MedicalAppointmentManagementSystem/MedicalAppointmentApp
Restaurar dependencias:

bash
Copiar código
dotnet restore
Compilar el proyecto:

bash
Copiar código
dotnet build
Ejecutar la aplicación:

bash
Copiar código
dotnet run
📸 Ejemplo de uso
markdown
Copiar código
==== Medical Appointment System ====
Select your role:
1. Administrator
2. Doctor
3. Patient
0. Exit
   Option:
   🧪 Datos de prueba
   El sistema incluye datos iniciales (pacientes, médicos y citas) cargados automáticamente desde el Seeder:

Paciente: John Doe - Documento: P001

Paciente: Jane Smith - Documento: P002

Doctor: Dr. Emily Brown - Documento: D001

Doctor: Dr. Robert Johnson - Documento: D002

👤 Autor
Fabian Camilo Lugo Orozco
📧 camilosnowman@gmail.com
🪪 CC: 1143*****4
👨‍💻 Clan: Caimán

📜 Licencia
Este proyecto fue desarrollado con fines educativos como parte de la prueba de desempeño de C#.
Puedes modificarlo y reutilizarlo con fines académicos o personales.

yaml
Copiar código

---

¿Quieres que agregue también un apartado de **diagrama de clases y casos de uso** (explicados en texto para el README)? (Sí / No)  
👉 Si dices que **sí**, los generamos enseguida.






Dijiste:
EN INGLES


ChatGPT dijo:
Perfect — here’s the README.md translated into English and ready to use for your project:

md
Copiar código
# 🏥 Medical Appointment Management System

## 📌 Project Overview

**Medical Appointment Management System** is a console-based application developed in **C#** that allows *Hospital San Vicente* to digitalize and optimize the management of medical appointments, patients, and doctors.  
The system centralizes all data, automates appointment scheduling, and ensures data integrity, consistency, and accessibility.

---

## 🎯 Objectives

- Eliminate the use of paper agendas and spreadsheets.
- Prevent duplicate appointments for the same patient or doctor.
- Make it easier to search, register, and manage patients and doctors.
- Automate appointment confirmation emails.
- Keep a complete history of appointments and email logs.

---

## ⚙️ Main Features

### 👤 Patient Management
- Register new patients.
- Edit patient information.
- Validate duplicate patients by ID/document.
- List all registered patients.

### 🩺 Doctor Management
- Register new doctors.
- Edit doctor information.
- Validate duplicate doctors by ID/document.
- List all doctors and filter by specialty.

### 📅 Appointment Management
- Schedule appointments and validate doctor/patient availability.
- Cancel appointments and mark them as **Cancelled**.
- Mark appointments as **Attended**.
- List appointments by patient or doctor.
- Send automatic email confirmation when an appointment is scheduled.
- Keep a log of sent emails with their status (“Sent” / “Not Sent”).

### 🗂️ Data Persistence
- Information managed using **List<>**, **Dictionary<,>**, and **LINQ**.
- Ready for integration with database technologies (e.g., EF Core, MySQL, PostgreSQL).

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET 8.0
- **ORM (Optional):** Entity Framework Core
- **Data Structures:** List, Dictionary, LINQ
- **Email:** MailKit / SMTP
- **Recommended IDE:** JetBrains Rider or Visual Studio

---

## 📁 Project Structure

MedicalAppointmentManagementSystem/
│
├─ Models/ # Domain classes (Patient, Doctor, Appointment, etc.)
├─ Services/ # Business logic (PatientService, DoctorService, etc.)
├─ Interface/ # Interfaces for dependency injection
├─ Utils/ # Helpers and utilities (ConsoleInput, Menus, etc.)
├─ Seeder/ # Initial demo data
├─ Bootstrap/ # App initialization and configuration
├─ Program.cs # Application entry point
└─ README.md # Project documentation

yaml
Copiar código

---

## 🖥️ Prerequisites

- .NET SDK 8.0 or higher
- Visual Studio / Rider / VS Code
- (Optional) SMTP email server configuration for email sending

---

## 🚀 Installation & Execution

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/MedicalAppointmentManagementSystem.git
Navigate to the project folder:

bash
Copiar código
cd MedicalAppointmentManagementSystem/MedicalAppointmentApp
Restore dependencies:

bash
Copiar código
dotnet restore
Build the project:

bash
Copiar código
dotnet build
Run the application:

bash
Copiar código
dotnet run
📸 Example Usage
markdown
Copiar código
==== Medical Appointment System ====
Select your role:
1. Administrator
2. Doctor
3. Patient
0. Exit
   Option:
   🧪 Demo Data (Seeder)
   The system includes initial demo data (patients, doctors, and appointments) loaded automatically by the Seeder:

Patient: John Doe - Document: P001

Patient: Jane Smith - Document: P002

Doctor: Dr. Emily Brown - Document: D001

Doctor: Dr. Robert Johnson - Document: D002

👤 Author
Fabian Camilo Lugo Orozco
📧 camilosnowman@gmail.com
🪪 ID: 1143*****4
👨‍💻 Clan: Caimán

📜 License
This project was developed as part of a C# performance assessment.
You are free to modify or use it for educational or personal purposes.

yaml
Copiar código

---

Would you like me to generate a simple **class diagram (UML)** and **use case diagram** (in text/markdown format) to include at the end of this README? (Yes / No)