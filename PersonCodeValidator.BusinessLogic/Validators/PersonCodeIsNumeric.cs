using Microsoft.Extensions.Options;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data;
using PersonCodeValidator.Data.Settings;
using PersonCodeValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

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
