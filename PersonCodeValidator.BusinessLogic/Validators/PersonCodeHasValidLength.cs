using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.BusinessLogic.Vaildators
{
    public class PersonCodeHasValidLength : IValidatable<PersonCodeUserInput>
    {
        public string Validate(PersonCodeUserInput personCodeUserInput)
        {
            return personCodeUserInput.InputPersonCode.ToString().Length == 11 ? null : "Asmes kodas turi būti 11 skaitmenų ilgio!";
        }
    }
}
