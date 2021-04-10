using NSubstitute;
using NUnit.Framework;
using PersonCodeValidator.BusinessLogic;
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace PersonCodeValidator.Tests
{
    public class PersonCodeDateValidatorTests
    {
        private IPersonCodeValidatorService _personCodeValidatorService;
        private PersonCodeHasValidDate _personCodeHasValidDateMock;
        private ResourceManager _resourceManager;


        [SetUp]
        public void Setup()
        {
            _resourceManager = new ResourceManager("PersonCodeValidator.Tests.Resources.TestValidationMessages-en-US", Assembly.GetExecutingAssembly());
            _personCodeHasValidDateMock = Substitute.For<PersonCodeHasValidDate>(_resourceManager);
            _personCodeValidatorService = new PersonCodeValidatorService(new List<IValidatable<PersonCode>>
            {
                _personCodeHasValidDateMock
            }
            );
        }

        [Test]
        public void ValidBirthDate_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("M", "49608280081");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void InvalidBirthDate_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("V", "49602350081");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("DateIsNotValid"), validationResult[0]);
        }

    }
}
