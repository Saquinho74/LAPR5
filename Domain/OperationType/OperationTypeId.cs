﻿using System;
using DDDNetCore.Domain.Shared;
using Newtonsoft.Json;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationTypeId : EntityId
    {
        [JsonConstructor]
        public OperationTypeId(Guid value) : base(value)
        {
        }

        public OperationTypeId(String value) : base(value)
        {
        }

        override
            protected  Object createFromString(String text){
            return new Guid(text);
        }

        override
            public String AsString(){
            Guid obj = (Guid) base.ObjValue;
            return obj.ToString();
        }
        
       
        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
        
    }
}