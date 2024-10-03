# Supplementary Specification (FURPS+)

## Functionality

_Specifies functionalities that:_

- _are common across several US/UC;_
- _are not related to US/UC, namely: Audit, Reporting and Security._

> **Audit and Reporting:**
>
>- Develop a real estate management application to facilitate the sale and lease of properties.
>
>- Property owners can contact Real Estate USA to enlist their properties for sale or rent.
>
>- Property owners interested in selling their properties must provide details such as the property type (house, apartment or land), area in square meters, location, distance from the city center, requested price, and photos. If the property is a house or apartment, they should also provide information about the number of bedrooms, bathrooms, parking spaces, and available equipment such as central heating or air conditioning.
>
>- If the property is a house, the owner must also include additional details such as the presence of a basement, inhabitable loft, and sun exposure.
>
>- Clients using the application should have the ability to sort properties based on various criteria such as property type, number of bedrooms, price, and location.
>
>- Clients can request to visit a property and the agent can confirm and schedule the visit. Both the client and the agent should receive notifications regarding the visit.
>
>- Once a property is sold or rented, it should be removed from the listing of available properties. The system should update the property status and notify the owner, agent, and client.
>
>- Store managers should be able to monitor the deals of every agent working in their store.
>
>- The Network Manager should have access to data from all stores to analyze performance metrics.
>
>- The System Administrator should be responsible for entering relevant information about employees and each store into the application.

> **Security:**
>
>- To access the application, users must authenticate themselves with a password consisting of seven alphanumeric characters, including uppercase letters and two digits
>
>- All details about the property should be accessible to clients except for the agent's commission, which is confidential information

## Usability

_Evaluates the user interface. It has several subcategories,
among them: error prevention; interface aesthetics and design; help and
documentation; consistency and standards._


- To avoid errors, all methods will be subjected to unit tests during implementation.
- The software must be designed to be user-friendly and easily navigable.
- The software interface must have a clean and professional appearance.
- The application must be able to support the English language.




## Reliability
_Refers to the integrity, compliance and interoperability of the software. The requirements to be considered are: frequency and severity of failure, possibility of recovery, possibility of prediction, accuracy, average time between failures._

- The application should operate continuously without any downtime, providing uninterrupted services to users around the clock, every day of the week
- The system should aim to minimize the occurrence of any errors or malfunctions, and if they occur, they should be promptly resolved to ensure minimal disruption to the users
- The software must be designed to ensure reliability and stability, with minimum possible downtime or system failures
- The software must be equipped with robust security features to protect sensitive and confidential information from unauthorized access or misuse.

## Performance
_Evaluates the performance requirements of the software, namely: response time, start-up time, recovery time, memory consumption, CPU usage, load capacity and application availability._

- All client requests must receive a response within a maximum of 5 seconds from the system
- The application should use minimal memory and CPU resources
- The software should be capable of efficiently handling a large volume of transactions and users.

## Supportability
_The supportability requirements gathers several characteristics, such as:
testability, adaptability, maintainability, compatibility,
configurability, installability, scalability and more._

- English language support will be available in the app.
- The system should be designed for easy maintenance.
- The software must come with comprehensive documentation and efficient customer support.
- The software should be compatible with upcoming updates.
- The software application should be developed with the potential for commercialization to other organizations in mind.






## +

### Design Constraints

_Specifies or constraints the system design process. Examples may include: programming languages, software process, mandatory standards/patterns, use of development tools, class library, etc._

- Java will be the chosen programming language for the development of the application.
- IntelliJ IDE will be utilized for the development of the application, with JavaFX 11 being utilized for the development of the graphical interface.
- The JUnit 5 framework will be employed to implement unit tests for the application.
- To produce a coverage report, the JaCoCo plugin will be used during the testing phase


### Implementation Constraints

_Specifies or constraints the code or construction of a system such
such as: mandatory standards/patterns, implementation languages,
database integrity, resource limits, operating system._


- The application should be developed using either IntelliJ IDE or NetBeans, and programmed in Java language.
- To access the application, users must be authenticated with a password that includes seven alphanumeric characters, with at least two digits and capital letters.
- The application must support English language.
- The graphical interface should be designed using JavaFX 11.
- All methods, except those that involve Input/Output operations, must have corresponding unit tests implemented using JUnit 5 framework.
- To measure code coverage, the team must use the JaCoCo plugin and generate a report.
- The team must use best practices for identifying requirements, as well as for OO software analysis and design during the development process.
- Recognized coding standards such as CamelCase should be used by the team.


### Interface Constraints
_Specifies or constraints the features inherent to the interaction of the
system being developed with other external systems._


- "The application graphical interface is to be developed in JavaFX 11."

### Physical Constraints

_Specifies a limitation or physical requirement regarding the hardware used to house the system, as for example: material, shape, size or weight._

- The application needs to have a database system in place to effectively store and manage data, including appropriate backup and redundancy measures.