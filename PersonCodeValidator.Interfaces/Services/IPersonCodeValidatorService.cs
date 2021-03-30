using PersonCodeValidator.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.Interfaces.Services
{
    public interface IPersonCodeValidatorService 
    {
        IEnumerable<string> Validate(PersonCodeUserInput personCodeUserInput);
        bool IsValidGenderParameter(string genderParameter);
    }
}
