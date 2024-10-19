# US 5.1.3

## 1. Context

As a Patient, I want to register for the healthcare application, so that I can create a user profile and book appointments online.

## 2. Requirements




## Client Specifications:

> *Question*: Dear client,
>In order for a patient to register himself in the IAM (assuming we're using an external IAM), is it necessary to already exist a patient profile (with name, email, medical record number, ...) in the system?
>If so, the patient profile will already be created, right? I'm asking this because of US5.1.3's description: "As a Patient, I want to register for the healthcare application, so that I can create a user profile and book appointments online".
>What info is already on the system when the patient registers himself and what info does he need to give after registering in the IAM?
>
> *Answer*: there are already a couple of topics similar to this in the forum, check all the previous info.
>generally speaking the admin will create the patient record, and only afterwards, the patient can self register. that action will link the patient record and the patient account profile.
>when registering, the patient will provide the email and phone number for the system to cross-check with the patient record



**Acceptance Criteria:**
* 5.1.16.1 - Patients can self-register using the external IAM system.
* 5.1.16.2 - During registration, patients provide personal details (e.g., name, email, phone) and create a profile
* 5.1.16.3 - The system validates the email address by sending a verification email with a confirmation link.
* 5.1.16.4 - Patients cannot list their appointments without completing the registration process


[//]: # (**Dependencies/References:**)
.

## 3. Analysis

### 3.1. Domain Model

The domain model is composed of the following entities:

- **Patient**: Represents a patient who can register for the healthcare application.

![Domain Model](C:\Users\Utilizador\Desktop\CURSO\3ºANO\ARQSI\projeto_milhoes\Docs\SprintA\domainModel\domainModel.puml)

## 4. Design

### 4.1. Realization

The sequence diagram outlines the interaction between the Customer Manager and the system components to list job
openings.
The domain model illustrates the key entities and relationships relevant to the job openings functionality.
This requires interactions between various system components including the UI, business logic,
and data persistence layers.


## 4.2 Sequence Diagram

![Sequence Diagram - Full](C:\Users\gonca\IdeaProjects\sem4pi-23-24-2dh3\docs\sprintB\1003\svg\1003-sequence-diagram-List_Job_Openings___Sequence_Diagram.png)

- The sequence diagram shows the process of listing job openings with filters.
  The Customer Manager requests to list job openings via the UI.
  The UI fetches filtering strategies from the controller and presents them to the Customer Manager.
- After selecting a strategy and inputting criteria, the controller uses the JobOpeningService to retrieve and
  filter job openings from the JobOpeningRepository.
- The filtered job openings are then returned and displayed to the Customer Manager.
  This process involves interactions between the UI, controller, service, filtering strategy,
  and repository to ensure the correct job openings are displayed based on the selected filters.

## 5. Implementation

- The implementation adheres to the design decisions outlined in the sequence diagram and domain model.
- The core components involved in the listing of job openings are the UI, the controller, the service, the filtering strategy, and the repository.
- These components collaborate to retrieve and filter job openings based on the criteria provided by the Customer Manager. Key implementation steps include:

**UI Layer**: Implementing the interface for the Customer Manager to request job openings and input filtering criteria.

**Controller Layer**: Handling requests from the UI, fetching filtering strategies, and delegating the job of retrieving and filtering job openings to the service layer.

**Service Layer**: Implementing the business logic to retrieve all job openings and apply the filtering criteria.

**Filtering Strategy**: Defining and applying various filtering criteria such as by description, date, or code.

**Repository Layer**: Interacting with the persistence layer to retrieve job openings from the database.

Key classes and methods were implemented to ensure the functionality works as intended and adheres to the outlined design.

## 6. Integration/Demonstration

Efforts were made to integrate the job openings listing functionality with other components of the system.
Integration testing was conducted to validate the functionality's interaction with existing modules and ensure smooth
operation.

## 7. Observations

Further refinement and optimization may be necessary based on user feedback and evolving business requirements.
The analysis of alternative solutions and related works can provide valuable insights for future enhancements.
Third-party works and references used during development should be duly acknowledged.