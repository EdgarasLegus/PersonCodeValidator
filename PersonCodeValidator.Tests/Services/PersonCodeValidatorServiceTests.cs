using NSubstitute;
using NUnit.Framework;
using PersonCodeValidator.BusinessLogic;
using PersonCodeValidator.BusinessLogic.Vaildators;
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace PersonCodeValidator.Tests
{
    public class PersonCodeValidatorServiceTests
    {
        private IPersonCodeValidatorService _personCodeValidatorService;
        private PersonCodeHasValidDate _personCodeHasValidDateMock;
        private PersonCodeHasValidGender _personCodeHasValidGender;
        private ResourceManager _resourceManager;


        [SetUp]
        public void Setup()
        {
            _resourceManager = new ResourceManager("PersonCodeValidator.Tests.Resources.TestValidationMessages-en-US", Assembly.GetExecutingAssembly());
            _personCodeHasValidDateMock = Substitute.For<PersonCodeHasValidDate>(_resourceManager);
            _personCodeHasValidGender = Substitute.For<PersonCodeHasValidGender>(_resourceManager);
            _personCodeValidatorService = new PersonCodeValidatorService(new List<IValidatable<PersonCode>>
            {
                _personCodeHasValidDateMock,
                _personCodeHasValidGender
            }
            );
        }

        [Test]
        public void ValidPersonCode_ShouldReturnEmptyString()
        {
            //Arrange
            var personCode = new PersonCode("V","36608214455");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void InValidPersonCode_ShouldReturnValidatorResults()
        {
            //Arrange
            var personCode = new PersonCode("M", "36618214455");
            var validationsErrorsList = new List<string>()
            {
                _resourceManager.GetString("DateIsNotValid"),
                _resourceManager.GetString("GenderIsNotValid")
            };

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(validationsErrorsList, validationResult);
        }


    }
}
