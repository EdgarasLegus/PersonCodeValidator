
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PersonCodeValidator.BusinessLogic
{
    public class PersonCodeValidatorService : IPersonCodeValidatorService
    {
        private readonly IReadOnlyList<IValidatable<PersonCodeUserInput>> _validators;

        public PersonCodeValidatorService(IReadOnlyList<IValidatable<PersonCodeUserInput>> validators)
        {
            _validators = validators;
        }

        public IEnumerable<string> Validate(PersonCodeUserInput personCodeUserInput)
        {
            return _validators.Select(v => v.Validate(personCodeUserInput)).Where(validationResult => validationResult != null);
        }

        public bool IsValidGenderParameter(string genderParameter)
        {
            return genderParameter == "V" ||
             genderParameter == "M";
            //return Enum.TryParse(genderParameter, out GenderParameter _);
        }
    }
}
