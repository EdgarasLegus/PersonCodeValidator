using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.Interfaces.Services
{
    public interface IPersonCodeValidatorService 
    {
        IEnumerable<string> Validate(PersonCode personCode);
        bool IsValidGenderParameter(string genderParameter);
    }
}
