using System;
using System.Collections.Generic;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.OperationType;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Mappers
{
    public class OperationTypeMapper
    {
        
            public static OperationTypeDto toDTO(OperationType operationType)
            {
                return new OperationTypeDto
                {
                    Id = operationType.Id.AsGuid().ToString(),
                    OperationTypeName = operationType.OperationTypeName.Value, // Convertendo o Guid para string
                    RequiredStaffEntry = operationType.RequiredStaffEntry.Value,
                    EstimatedDuration = operationType.EstimatedDuration.Value,
                };
            }

            public static List<OperationTypeDto> toDTOList(List<OperationType> operationTypes)
            {
                return operationTypes.ConvertAll(operationType => new OperationTypeDto
                {
                    Id = operationType.Id.AsGuid().ToString(),
                    OperationTypeName = operationType.OperationTypeName.Value, // Convertendo o Guid para string
                    RequiredStaffEntry = operationType.RequiredStaffEntry.Value,
                    EstimatedDuration = operationType.EstimatedDuration.Value,
                });
            }

            // Método para converter de OperationDto para Operation
            public static OperationType toDomain(OperationTypeDto dto)
            {
                return new OperationType(
                    new OperationTypeName(dto.OperationTypeName), // Mapeando a descrição
                    new RequiredStaffEntry(dto.RequiredStaffEntry), // Mapeando a Deadline
                    new EstimatedDuration(dto.EstimatedDuration) // Mapeando a Deadline
                );
            }

            // Método para converter uma lista de OperationDto para uma lista de Operation
            public static List<OperationType> toDomainList(List<OperationTypeDto> dtos)
            {
                return dtos.ConvertAll(dto => toDomain(dto));
            }
        }
    
}