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

* PARA TESTAR
  {
  "id": "1",
  "description": "string",
  "priority": "1",
  "operationTypeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "deadline": "2025-10-22T15:35:42.660Z"
  }



  

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

