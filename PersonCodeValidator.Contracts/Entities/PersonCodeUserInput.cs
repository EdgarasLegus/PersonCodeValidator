using PersonCodeValidator.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.Contracts.Entities
{
    public class PersonCodeUserInput
    {
        public GenderParameter InputGenderParameter { get; }
        public PersonCode InputPersonCode { get; }

        public PersonCodeUserInput(string inputGenderParameter, string personCode)
        {
            InputGenderParameter = (GenderParameter)Enum.Parse(typeof(GenderParameter), inputGenderParameter);
            InputPersonCode = new PersonCode(personCode);
        }
    }


}
