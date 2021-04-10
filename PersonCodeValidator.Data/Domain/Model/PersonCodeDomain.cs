using PersonCodeValidator.Data.Domain.Enum;
using System;

namespace PersonCodeValidator.Data
{
    public class PersonCodeDomain
    {
        public InputGenderParameter InputGenderParameter { get; set; }
        public InputGender InputGender { get; }
        public string BirthDate { get; }
        public string IdentificationNumbers { get; }

        public PersonCodeDomain(string inputGenderParameter, string personCode)
        {
            InputGenderParameter = (InputGenderParameter)Enum.Parse(typeof(InputGenderParameter), inputGenderParameter);
            InputGender = (InputGender)Enum.Parse(typeof(InputGender), personCode.Substring(0, 1));
            BirthDate = personCode.Substring(1, 6);
            IdentificationNumbers = personCode[7..];
        }

        public override string ToString()
        {
            return $"{(int)InputGender}" + $"{BirthDate}" + $"{IdentificationNumbers}";
        }
    }
}
