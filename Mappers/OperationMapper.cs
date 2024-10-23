using System;
using System.Collections.Generic;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.OperationType;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Mappers
{
    public class OperationMapper
    {
        public static OperationDto toDTO(Operation operation)
        {
            return new OperationDto
            { 
                Id = operation.Id.AsGuid().ToString(), 
                Priority = operation.Priority.Value.ToString(),// Convertendo o Guid para string
                Description = operation.Description.Value,  
                OperationTypeId = operation.Type.AsString(),           // Convertendo o tipo de operação para string
                Deadline = operation.Deadline.Value.ToString("yyyy-MM-dd") // Formatando a data de deadline como string
            };
        }
    
        public static List<OperationDto> toDTOList(List<Operation> operations)
        {
            return operations.ConvertAll(operation => new OperationDto
            {
                Id = operation.Id.AsGuid().ToString(), 
                Priority = operation.Priority.Value.ToString(),// Convertendo o Guid para string
                Description = operation.Description.Value,           // Acessando a propriedade 'Value' do Value Object 'Description'
                OperationTypeId = operation.Type.AsString(),           // Convertendo o tipo de operação para string
                Deadline = operation.Deadline.Value.ToString("yyyy-MM-dd") // Formatando a data de deadline como string
            });
        }

        // Método para converter de OperationDto para Operation
        public static Operation toDomain(OperationDto dto)
        {
           return new Operation(
                new OperationDescription(dto.Description), 
                new Priority(int.Parse(dto.Priority)), 
                new Deadline(DateTime.Parse(dto.Deadline)), 
                new OperationTypeId(dto.OperationTypeId)
            );
        }

        // Método para converter uma lista de OperationDto para uma lista de Operation
        public static List<Operation> toDomainList(List<OperationDto> dtos)
        {
            return dtos.ConvertAll(dto => toDomain(dto));
        }
    }
}
