using PersonCodeValidator.Contracts.Enums;
using System;

namespace PersonCodeValidator.Contracts.Entities
{
    public class PersonCode
    {

        public Gender Gender { get; }
        public string BirthDate { get; }
        public string IdentificationNumbers { get; }

        public PersonCode(string personCode)
        {
            Gender = (Gender)Enum.Parse(typeof(Gender), personCode.Substring(0, 1));
            BirthDate = personCode.Substring(1, 6);
            IdentificationNumbers = personCode.Substring(7, 4);
        }

    }
}
