using System;
using DDDNetCore.Domain.Shared;
using Newtonsoft.Json;

namespace DDDNetCore.Domain.Staff
{ 
    public class StaffId : EntityId
    {
        private string _fullId;
        private string _role;
        private string _recruitmentYear;
        private string _number;

        // Private constructor that initializes the fields
         public StaffId(string value) : base(value)
        {
            _fullId = value;
            _role = value.Substring(0, 1);
            _recruitmentYear = value.Substring(1, 4);
            _number = value.Substring(5, 4);
        }

        public static StaffId Create(string value)
        {
            return new StaffId(value);
        }

        protected override object createFromString(string text)
        {
            return new
            {
                FullId = text,
                Role = text.Substring(0, 1),
                RecruitmentYear = text.Substring(1, 4),
                Number = text.Substring(5, 4)
            };
        }

        public override string AsString()
        {
            return _fullId; 
        }


        // Method to return the StaffId as a GUID
        public Guid AsGuid()
        {
            return (Guid)base.ObjValue;
        }
    }
}
