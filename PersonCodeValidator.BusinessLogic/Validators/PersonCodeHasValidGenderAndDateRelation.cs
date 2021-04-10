using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data.Domain.Enum;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace PersonCodeValidator.BusinessLogic.Validators
{
    public class PersonCodeHasValidGenderAndDateRelation : IValidatable<PersonCode>
    {
        private readonly ResourceManager _resourceManager;
        public PersonCodeHasValidGenderAndDateRelation(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public string Validate(PersonCode personCode)
        {
            var thisMellenium = new DateTime(2000, 01, 01);
            var birthDate = DateTime.ParseExact(personCode.InputPersonCode.BirthDate, "yyMMdd", CultureInfo.InvariantCulture);
            var gender = personCode.InputPersonCode.InputGender;

            return birthDate < thisMellenium && (gender == InputGender.Female || gender == InputGender.Male)
                ? null
                : birthDate >= thisMellenium && (gender == InputGender.FemaleBornThisMillenium || gender == InputGender.MaleBornThisMillenium)
                    ? null
                    : _resourceManager.GetString("DateAndGenderRelationIsInvalid");
        }
    }
}
