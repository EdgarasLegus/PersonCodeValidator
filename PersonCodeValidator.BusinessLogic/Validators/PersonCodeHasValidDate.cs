using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using System;
using System.Globalization;
using PersonCodeValidator.Data.Settings;
using Microsoft.Extensions.Options;
using System.Resources;
using System.Reflection;

namespace PersonCodeValidator.BusinessLogic.Validators
{
    public class PersonCodeHasValidDate : IValidatable<PersonCode>
    {
        private readonly ResourceManager _resourceManager;
        public PersonCodeHasValidDate(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public string Validate(PersonCode personCode)
        {
            //var temp = DateTime.ParseExact(personCode.InputPersonCode.BirthDate, "yyMMdd", CultureInfo.InvariantCulture);
            return DateTime.TryParseExact(personCode.InputPersonCode.BirthDate, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out _)
                ? null : _resourceManager.GetString("DateIsNotValid");
        }
    }
}
