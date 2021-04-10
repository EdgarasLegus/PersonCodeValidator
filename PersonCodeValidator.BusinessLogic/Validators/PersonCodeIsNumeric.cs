using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using System.Resources;

namespace PersonCodeValidator.BusinessLogic.Vaildators
{
    public class PersonCodeIsNumeric : IValidatable<PersonCode>
    {
        private readonly ResourceManager _resourceManager;
        public PersonCodeIsNumeric(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public string Validate(PersonCode personCode)
        {
            return long.TryParse(personCode.InputPersonCode.ToString(), out _) ? null : _resourceManager.GetString("IsNotNumeric");
        }
    }
}
