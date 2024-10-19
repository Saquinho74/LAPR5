using System;
using System.Collections.Generic;

namespace DDDNetCore.Test.unit.MyLibrary
{
    public class PatientTests
    {
        [Fact]
        public void CreatePatient_ShouldReturnPatient_WithValidData()
        {
            // Arrange
            var patientID = new PatientID(Guid.NewGuid());
            var dateOfBirth = new DateOfBirth(new DateTime(1990, 5, 24));
            var gender = new Gender("Male");
            var medicalRecordNumber = new MedicalRecordNumber("MR123456");
            var contactInformation = new ContactInformation("123 Main St", "555-1234", "patient@example.com");
            var emergencyContact = new EmergencyContact("John Doe", "555-5678");
            var appointmentHistory = new AppointmentHistory(new List<string> { "Checkup on 01/01/2024" });
            var allergiesMedicalConditions = new AllergiesMedicalConditions("None");

            // Act
            var patient = new Patient(patientID, dateOfBirth, gender, medicalRecordNumber, contactInformation, emergencyContact, appointmentHistory, allergiesMedicalConditions);

            // Assert
            Assert.NotNull(patient);
            Assert.Equal(patientID, patient.PatientID);
            Assert.Equal(dateOfBirth, patient.DateOfBirth);
            Assert.Equal(gender, patient.Gender);
            Assert.Equal(medicalRecordNumber, patient.MedicalRecordNumber);
            Assert.Equal(contactInformation, patient.ContactInformation);
            Assert.Equal(emergencyContact, patient.EmergencyContact);
            Assert.Equal(appointmentHistory, patient.AppointmentHistory);
            Assert.Equal(allergiesMedicalConditions, patient.AllergiesMedicalConditions);
        }

        [Fact]
        public void CreatePatient_ShouldThrowArgumentNullException_IfPatientIDIsNull()
        {
            // Arrange
            DateOfBirth dateOfBirth = new DateOfBirth(new DateTime(1990, 5, 24));
            Gender gender = new Gender("Male");
            MedicalRecordNumber medicalRecordNumber = new MedicalRecordNumber("MR123456");
            ContactInformation contactInformation = new ContactInformation("123 Main St", "555-1234", "patient@example.com");
            EmergencyContact emergencyContact = new EmergencyContact("John Doe", "555-5678");
            AppointmentHistory appointmentHistory = new AppointmentHistory(new List<string> { "Checkup on 01/01/2024" });
            AllergiesMedicalConditions allergiesMedicalConditions = new AllergiesMedicalConditions("None");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Patient(null, dateOfBirth, gender, medicalRecordNumber, contactInformation, emergencyContact, appointmentHistory, allergiesMedicalConditions));
        }

        [Fact]
        public void CreatePatient_ShouldThrowArgumentNullException_IfDateOfBirthIsNull()
        {
            // Arrange
            PatientID patientID = new PatientID(Guid.NewGuid());
            Gender gender = new Gender("Male");
            MedicalRecordNumber medicalRecordNumber = new MedicalRecordNumber("MR123456");
            ContactInformation contactInformation = new ContactInformation("123 Main St", "555-1234", "patient@example.com");
            EmergencyContact emergencyContact = new EmergencyContact("John Doe", "555-5678");
            AppointmentHistory appointmentHistory = new AppointmentHistory(new List<string> { "Checkup on 01/01/2024" });
            AllergiesMedicalConditions allergiesMedicalConditions = new AllergiesMedicalConditions("None");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Patient(patientID, null, gender, medicalRecordNumber, contactInformation, emergencyContact, appointmentHistory, allergiesMedicalConditions));
        }

        [Fact]
        public void CreatePatient_ShouldThrowArgumentNullException_IfMedicalRecordNumberIsNull()
        {
            // Arrange
            PatientID patientID = new PatientID(Guid.NewGuid());
            DateOfBirth dateOfBirth = new DateOfBirth(new DateTime(1990, 5, 24));
            Gender gender = new Gender("Male");
            ContactInformation contactInformation = new ContactInformation("123 Main St", "555-1234", "patient@example.com");
            EmergencyContact emergencyContact = new EmergencyContact("John Doe", "555-5678");
            AppointmentHistory appointmentHistory = new AppointmentHistory(new List<string> { "Checkup on 01/01/2024" });
            AllergiesMedicalConditions allergiesMedicalConditions = new AllergiesMedicalConditions("None");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Patient(patientID, dateOfBirth, gender, null, contactInformation, emergencyContact, appointmentHistory, allergiesMedicalConditions));
        }

        [Fact]
        public void CreatePatient_AllOptionalValuesNull_ShouldSucceed()
        {
            // Arrange
            var patientID = new PatientID(Guid.NewGuid());
            var dateOfBirth = new DateOfBirth(new DateTime(1990, 5, 24));
            var gender = new Gender("Male");
            var medicalRecordNumber = new MedicalRecordNumber("MR123456");

            // Act
            var patient = new Patient(patientID, dateOfBirth, gender, medicalRecordNumber, null, null, null, null);

            // Assert
            Assert.NotNull(patient);
            Assert.Equal(patientID, patient.PatientID);
            Assert.Equal(dateOfBirth, patient.DateOfBirth);
            Assert.Equal(gender, patient.Gender);
            Assert.Equal(medicalRecordNumber, patient.MedicalRecordNumber);
            Assert.Null(patient.ContactInformation);
            Assert.Null(patient.EmergencyContact);
            Assert.Null(patient.AppointmentHistory);
            Assert.Null(patient.AllergiesMedicalConditions);
        }
    }
}
