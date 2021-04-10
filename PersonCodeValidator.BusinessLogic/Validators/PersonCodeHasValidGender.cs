using Microsoft.Extensions.Options;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data;
using PersonCodeValidator.Data.Domain.Enum;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace PersonCodeValidator.BusinessLogic.Vaildators
{
    public class PersonCodeHasValidGender : IValidatable<PersonCode>
    {
        private readonly ResourceManager _resourceManager;
        public PersonCodeHasValidGender(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public string Validate(PersonCode personCode)
        {
            if (personCode.InputPersonCode.InputGenderParameter == InputGenderParameter.M
                && (personCode.InputPersonCode.InputGender == InputGender.Female || personCode.InputPersonCode.InputGender == InputGender.FemaleBornThisMillenium))
                return null;
            else if (personCode.InputPersonCode.InputGenderParameter == InputGenderParameter.V
                && (personCode.InputPersonCode.InputGender == InputGender.Male || personCode.InputPersonCode.InputGender == InputGender.MaleBornThisMillenium))
                return null;
            else 
                return _resourceManager.GetString("GenderIsNotValid");
            //return Enum.IsDefined(typeof(Gender), personCodeUserInput.InputPersonCode.Gender) ? null : "Lyties skaitmuo yra neteisingas!";
        }
    }
}
