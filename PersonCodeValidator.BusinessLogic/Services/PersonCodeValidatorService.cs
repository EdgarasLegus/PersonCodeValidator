
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data;
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
        private readonly IReadOnlyList<IValidatable<PersonCode>> _validators;

        public PersonCodeValidatorService(IReadOnlyList<IValidatable<PersonCode>> validators)
        {
            _validators = validators;
        }

        public IEnumerable<string> Validate(PersonCode personCode)
        {
            return _validators.Select(v => v.Validate(personCode)).Where(validationResult => validationResult != null);
        }

        public bool IsValidGenderParameter(string genderParameter)
        {
            return genderParameter == "V" ||
             genderParameter == "M";
        }
    }
}
