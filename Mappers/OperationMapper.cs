using System.Collections.Generic;
using DDDNetCore.Domain.Operation;

namespace DDDNetCore.Mappers;

public class OperationMapper
{
    public static OperationDto toDTO(Operation operation)
    {
        return new OperationDto
        { 
            Id = operation.Id.AsGuid().ToString(),               // Convertendo o Guid para string
            Description = operation.Description.Value,           // Acessando a propriedade 'Value' do Value Object 'Description'
            OperationType = operation.Type.ToString(),           // Convertendo o tipo de operação para string
            Deadline = operation.Deadline.Value.ToString("yyyy-MM-dd") // Formatando a data de deadline como string
        };
    }
    
    public static List<OperationDto> toDTOList(List<Operation> operations)
    {
        return operations.ConvertAll(operation => new OperationDto
        {
            Id = operation.Id.AsGuid().ToString(),               // Convertendo o Guid para string
            Description = operation.Description.Value,           // Acessando a propriedade 'Value' do Value Object 'Description'
            OperationType = operation.Type.ToString(),           // Convertendo o tipo de operação para string
            Deadline = operation.Deadline.Value.ToString("yyyy-MM-dd") // Formatando a data de deadline como string
        });
    }
}