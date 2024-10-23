using System;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Patient;
using DDDNetCore.Domain.Shared;

namespace DDDSample1.Domain.Patients
{
    public class Patient : Entity<PatientId>
    {

        // Value Objects
        public DateOfBirth DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public MedicalRecordNumber MedicalRecordNumber { get; private set; }
        public ContactInformation ContactInformation { get; private set; }
        public EmergencyContact EmergencyContact { get; private set; }
        public AppointmentHistory AppointmentHistory { get; private set; }
        public AllergiesMedicalConditions AllergiesMedicalConditions { get; private set; }
        public bool Active { get; private set; }

        public Patient()
        {
            this.Active = true;
        }

        // Constructor
        public Patient(PatientId patientId, DateOfBirth dateOfBirth, Gender gender,
            MedicalRecordNumber medicalRecordNumber, ContactInformation contactInformation,
            EmergencyContact emergencyContact, AppointmentHistory appointmentHistory,
            AllergiesMedicalConditions allergiesMedicalConditions)
        {
            Id = patientId;
            DateOfBirth = dateOfBirth ?? throw new ArgumentNullException(nameof(dateOfBirth));
            Gender = gender;
            MedicalRecordNumber = medicalRecordNumber ?? throw new ArgumentNullException(nameof(medicalRecordNumber));
            ContactInformation = contactInformation ?? throw new ArgumentNullException(nameof(contactInformation));
            EmergencyContact = emergencyContact ?? throw new ArgumentNullException(nameof(emergencyContact));
            AppointmentHistory = appointmentHistory ?? throw new ArgumentNullException(nameof(appointmentHistory));
            AllergiesMedicalConditions = allergiesMedicalConditions;
        }

        public void ChangeDateOfBirth(DateOfBirth dateOfBirth)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the date of birth");
            this.DateOfBirth = dateOfBirth;
            {

            }
        }

        public void ChangeGender(Gender gender)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the date of birth");
            this.Gender = gender;
            {
            }
        }



        // Value Objects and Identity

        public void ChangeMedicalRecordNumber(MedicalRecordNumber medicalRecordNumber)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the medical record number");
            this.MedicalRecordNumber = medicalRecordNumber;
            {
            }
        }

        public void ChangeContactInformation(ContactInformation contactInformation)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the contact information");
            this.ContactInformation = contactInformation;
            {
                
            }
        }

        public void ChangeEmergencyContact(EmergencyContact emergencyContact)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the emergency contact");
            this.EmergencyContact = emergencyContact;
            {
                
            }
        }

        public void ChangeAppointmentHistory(AppointmentHistory appointmentHistory)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the appointment history");
            this.AppointmentHistory = appointmentHistory;
            {
                
            }
        }

        public void ChangeAllergiesMedicalConditions(AllergiesMedicalConditions allergiesMedicalConditions)
        {
            if(!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the allergies and medical conditions");
            this.AllergiesMedicalConditions = AllergiesMedicalConditions;
        }
    }
}

