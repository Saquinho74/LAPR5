﻿using System;
using System.Collections.Generic;
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
        
        public Patient( ) {}

        // Constructor
        public Patient(PatientId patientID, DateOfBirth dateOfBirth, Gender gender, 
                        MedicalRecordNumber medicalRecordNumber, ContactInformation contactInformation,
                        EmergencyContact emergencyContact, AppointmentHistory appointmentHistory,
                        AllergiesMedicalConditions allergiesMedicalConditions)
        {
            Id = patientID;
            DateOfBirth = dateOfBirth ?? throw new ArgumentNullException(nameof(dateOfBirth));
            Gender = gender;
            MedicalRecordNumber = medicalRecordNumber ?? throw new ArgumentNullException(nameof(medicalRecordNumber));
            ContactInformation = contactInformation ?? throw new ArgumentNullException(nameof(contactInformation));
            EmergencyContact = emergencyContact ?? throw new ArgumentNullException(nameof(emergencyContact));
            AppointmentHistory = appointmentHistory ?? throw new ArgumentNullException(nameof(appointmentHistory));
            AllergiesMedicalConditions = allergiesMedicalConditions;
        }
    }
    
   

    // Value Objects and Identity
    
    }   
