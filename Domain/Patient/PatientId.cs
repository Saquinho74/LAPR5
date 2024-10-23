using System;
using System.Text.Json.Serialization;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Patient;

public class PatientId : EntityId
{
    
    public Guid Value { get; private set; }
    
    [Newtonsoft.Json.JsonConstructor]
    public PatientId(Guid value) : base(value)
    {
        this.Value = value;
    }
    
    public PatientId(string value) : base(new Guid(value))
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