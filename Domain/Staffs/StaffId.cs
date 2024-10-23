using System;
using DDDNetCore.Domain.Shared;
using Newtonsoft.Json;

namespace DDDNetCore.Domain.Staffs
{
    public class StaffId : EntityId
    {
        private string Role;
        private string RecruitmentYear;
        private string SequentialNumber;
        private string Value;

        [JsonConstructor] 
        public StaffId(string id ) : base(id)
        {
            Value = id;
            string[] parts = id.Split();
            if (id.Length > 10)
            {
                throw new BusinessRuleValidationException("Id has to many characters");
            }
            Role = parts[0];
            RecruitmentYear = parts[1] + parts[2] + parts[3] + parts[4];
            SequentialNumber = parts[5] + parts[6] + parts[7] + parts[8] + parts[9];

        }

        protected override object createFromString(string text)
        {
            return new StaffId(text);
        }

        public override string AsString()
        {
            return Value;
        }
        
    }
}