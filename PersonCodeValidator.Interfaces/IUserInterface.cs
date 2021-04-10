using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.Interfaces
{
    public interface IUserInterface
    {
        string GetGenderParameterInput();
        IEnumerable<string> GetValidationResult(string inputGenderParameter, string personCode);
    }
}
