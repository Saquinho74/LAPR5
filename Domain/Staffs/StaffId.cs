using System;
using DDDNetCore.Domain.Shared;
using Newtonsoft.Json;

namespace DDDNetCore.Domain.Staff;

public class StaffId : EntityId
{
    private string _fullId;
    private string _role;
    private string _recruitmenteYear;
    private string _number;
    
    protected StaffId(string value) : base(value)
    {
        _fullId = value;
        _role = value.Substring(0, 1);
        _recruitmenteYear = value.Substring(1, 4);
        _number = value.Substring(5, 4);
    }

    public static StaffId Create(string value)
    {
        return new StaffId(value);
    }

    protected override object createFromString(string text)
    {
        return new StaffId(text);
    }

    override
    public String AsString()
    {
        Guid obj = (Guid) base.ObjValue;
        return obj.ToString();
    }

    public Guid AsGuid()
    {
        return (Guid) base.ObjValue;
    }
}