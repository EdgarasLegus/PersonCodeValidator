using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersonCodeValidator.BusinessLogic.Validators
{
    public class PersonCodeHasValidDate : IValidatable<PersonCodeUserInput>
    {

        public string Validate(PersonCodeUserInput personCodeUserInput)
        {
            return DateTime.TryParseExact(personCodeUserInput.InputPersonCode.BirthDate, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out _) 
                ? null : "Gimimo data yra neteisinga";
        }
    }
}
