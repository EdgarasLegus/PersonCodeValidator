using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using System.Resources;

namespace PersonCodeValidator.BusinessLogic.Vaildators
{
    public class PersonCodeHasValidLength : IValidatable<PersonCode>
    {
        private readonly ResourceManager _resourceManager;
        public PersonCodeHasValidLength(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public string Validate(PersonCode personCode)
        {
            return personCode.InputPersonCode.ToString().Length == 11 ? null : _resourceManager.GetString("LengthIsNotValid");
        }
    }
}
