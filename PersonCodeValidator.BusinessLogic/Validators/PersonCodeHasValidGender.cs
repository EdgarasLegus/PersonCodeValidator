using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Contracts.Enums;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCodeValidator.BusinessLogic.Vaildators
{
    public class PersonCodeHasValidGender : IValidatable<PersonCodeUserInput>
    {
        public string Validate(PersonCodeUserInput personCodeUserInput)
        {
            if (personCodeUserInput.InputGenderParameter == GenderParameter.M
                && (personCodeUserInput.InputPersonCode.Gender == Gender.Female || personCodeUserInput.InputPersonCode.Gender == Gender.FemaleBornThisMillenium))
                return null;
            else if (personCodeUserInput.InputGenderParameter == GenderParameter.V
                && (personCodeUserInput.InputPersonCode.Gender == Gender.Male || personCodeUserInput.InputPersonCode.Gender == Gender.MaleBornThisMillenium))
                return null;
            else 
                return "Lyties skaitmuo yra neteisingas!";
            //return Enum.IsDefined(typeof(Gender), personCodeUserInput.InputPersonCode.Gender) ? null : "Lyties skaitmuo yra neteisingas!";
        }
    }
}
