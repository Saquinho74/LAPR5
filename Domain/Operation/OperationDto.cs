﻿using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public class OperationDto
    {
        public string Id { get; set; }

        public string Description { get; set; }
        
        public string Type { get; set; }
        
        public string Deadline { get; set; }
        
        public string OperationType { get; set; }
        
        
    }
}