using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.BusinessLogic.Vaildators
{
    public class PersonCodeIsNumeric : IValidatable<PersonCodeUserInput>
    {
        public string Validate(PersonCodeUserInput personCodeUserInput)
        {
            return long.TryParse(personCodeUserInput.InputPersonCode.ToString(), out _) ? null : "Asmens kodas turi būti skaičiumi!";
        }
    }
}
