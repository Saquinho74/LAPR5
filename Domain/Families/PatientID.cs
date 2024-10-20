﻿using System;
using System.Text.Json.Serialization;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class PatientID : EntityId
{
    
    // Property to store the value for EF Core mapping
    [JsonPropertyName("value")]
    public Guid Value { get; private set; }
    
    [Newtonsoft.Json.JsonConstructor]
    public PatientID(Guid value) : base(value)
    {
        this.Value = value;
    }
    
    public PatientID(string value) : base(new Guid(value))
    {
        this.Value = new Guid(value);
    }
    
    protected override object createFromString(string text)
    {
        return new Guid(text);
    }

    public override string AsString()
    {
        return Value.ToString();
    }

    public Guid AsGuid()
    {
        return Value;
    }
}