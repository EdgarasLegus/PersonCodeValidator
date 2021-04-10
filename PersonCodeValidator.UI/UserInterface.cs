using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.UI
{
    public class UserInterface : IUserInterface
    {
        private readonly IPersonCodeValidatorService _personCodeValidatorService;

        public UserInterface(IPersonCodeValidatorService personCodeValidatorService)
        {
            _personCodeValidatorService = personCodeValidatorService;
        }

        public string GetGenderParameterInput()
        {
            string genderParameter;
            do
            {
                Console.WriteLine("Įveskite lytį (V/M):");
                genderParameter = Console.ReadLine().ToUpper();
            }
            while (!_personCodeValidatorService.IsValidGenderParameter(genderParameter));
                return genderParameter;
        }

        public IEnumerable<string> GetValidationResult(string inputGenderParameter, string personCode)
        {
            var personCodeUserImput = new PersonCode(inputGenderParameter, personCode);
            var validationResult = _personCodeValidatorService.Validate(personCodeUserImput);
            return validationResult;
        }
    }
}
