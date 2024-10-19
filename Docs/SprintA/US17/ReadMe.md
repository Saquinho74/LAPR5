# US 5.1.16

## 1. Context

Esta tarefa está relacionada à User Story (US) 5.1.16, que envolve a funcionalidade para os médicos solicitarem operações, 
garantindo que os pacientes tenham acesso ao cuidado médico necessário. 
Esta é a primeira vez que esta tarefa está sendo desenvolvida como parte do projeto de aprimoramento do sistema de gestão de saúde.

## 2. Requirements
A funcionalidade a ser desenvolvida permitirá que os médicos solicitem operações para os pacientes.
A solicitação incluirá a seleção do paciente, o tipo de operação, a prioridade e a sugestão de um prazo.
O sistema deve garantir que o tipo de operação seja compatível com a especialização do médico.

## Client Specifications:

> *Question*: Q68 Pedro – US1003 – Na us1003 é pedido que se liste job openings, há algum critério para definir quais
> listar? Ou são as do sistema inteiro?
> *Answer*: A68. Suponho que poder filtrar por Customer e data seja útil. Também poder filtrar apenas as activas ou
> todas parece-me útil.

> *Question*: Q87 Lopes – US1003 – Relativamente a uma questão já colocada foi referido que "pode-se filtrar por
> Customer" nesta US.
> Nesta caso qual será a forma que o Customer Manager utilizará para filtrar as Job Openings por Costumer (nome,
> email,...)?
> E quando se refere a "poder filtrar por data" significa que é uma determinada data ou um intervalo de tempo?
> *Answer*: A87. O Customer é tipicamente uma empresa e tem um nome. Também já foi referida a existência de um customer
> code.
> Quanto ao filtro por data se estiverem no papel do customer manager que tem de consultar job openings faz sentido ser
> para um dia? Ou seja ele teria de sabe em que dia é que registou o job opening que está a pesquisar…

> *Question*: Q95 Varela – [1003] Job Openings Ativas – A resposta à questão Q68 suscitou-nos algumas dúvidas sobre uma
> job opening no estado "ativa".
> Em que instante uma job opening se torna ativa? É quando é criada e tem um conjunto de requisitos associada a si? É
> quando está ligada a um processo de recrutamento ainda a decorrer?
> Agradecíamos alguns esclarecimentos
> *Answer*: A95. No contexto da Q68 a referência a activa surge no contexto de datas.
> Uma job opening cujo processo já tenha terminado não está ativa.

> *Question*: Q96 Semikina – [1003] - As Customer Manager, I want to list job openings – Em relação à listagem dos jobs
> openings,
> um customer manager pode listar todos os jobs openings ou apenas os que lhe foram atribuídos.
> Posto de outra forma, os job openings são atribuídos a um customer manager específico, e o mesmo só pode ter acesso à
> sua lista de job openings?
> *Answer*: A96. Ver Q68. Penso que faz sentido listar apenas os “seus” job openings.


> *Question*: Q120 Varela – [US1003] Job Opening Status- O cliente esclareceu o aspeto do status de uma job opening nas
> questões Q68 e Q95.
> Disse que uma job opening deixava de estar ativa quando o seu processo de recrutamento termina-se.
> Contudo, em que estado estão as job openings que já foram registadas mas ainda não têm um processo de recrutamento
> associado a si?
> *Answer*: A120. Relativamente ao estado (nome do estado) em que estão depois de serem registadas mas ainda não terem
> um processo eu não sei o que responder.
> Mas posso acrescentar que se não têm processo então não têm datas para as fases do processo e, portanto,
> parece-me que ainda não entraram na fase de application, pelo que ninguém tem “oficialmente” conhecimento dessa oferta
> de emprego e não devem haver candidaturas para essa oferta.

**Acceptance Criteria:**
* 5.1.16.1 -  Os médicos podem criar uma solicitação de operação selecionando o paciente, tipo de operação, prioridade e prazo sugerido.
* 5.1.16.2 -  O sistema valida que o tipo de operação corresponde à especialização do médico.
* 5.1.16.3 -  A solicitação de operação deve incluir:
- ID do Paciente
- ID do Médico
- Tipo de Operação
- Prazo
- Prioridade
* 5.1.16.4 - O sistema confirma a submissão bem-sucedida da solicitação de operação.
* 5.1.16.5 - O sistema registra a solicitação de operação no histórico médico do paciente.

**Dependencies/References:**

Há uma dependência relacionada à US5.1.15, que pode impactar a capacidade de recuperar informações sobre pacientes e
médicos necessárias para criar solicitações de operações.

## 3. Analysis

- Durante a fase de análise, foram considerados diversos fatores para garantir a implementação eficiente da funcionalidade de solicitação de operações. 
- Isso envolveu entender as necessidades dos médicos, definir os critérios necessários para criar solicitações e determinar as regras de validação com base nas especializações. 
- As informações obtidas nas aulas, nas sessões de esclarecimento foram cruciais para refinar os requisitos e critérios de aceitação.


### 3.1. Domain Model

The domain model is composed of the following entities:

- **JobOpening**: Represents a job opening in the company.

![Domain Model](C:\Users\gonca\IdeaProjects\sem4pi-23-24-2dh3\docs\sprintB\1003\svg\1003-domain-model.png)

## 3.2 System Sequence Diagram

![System Sequence Diagram - Full](C:\Users\gonca\IdeaProjects\sem4pi-23-24-2dh3\docs\sprintB\1003\svg\1003-system-sequence-diagram-System_Sequence_Diagram__SSD____List_job_openings.png)

- The System Sequence Diagram (SSD) for listing job openings illustrates the interaction between the "Customer Manager" and the System.
  Initially, the Customer Manager requests the list of job openings. The System responds by asking the Customer Manager to select a filtering strategy
  (e.g., no filter, by description, by date, or by code).
  After selecting a strategy, the System prompts for the filtering criteria, which the Customer Manager submits.
  Finally, the System processes the criteria and displays the filtered list of job openings to the Customer Manager.

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