using NSubstitute;
using NUnit.Framework;
using PersonCodeValidator.BusinessLogic;
using PersonCodeValidator.BusinessLogic.Vaildators;
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
    public class PersonCodeNumericValidatorTests
    {
        private IPersonCodeValidatorService _personCodeValidatorService;
        private PersonCodeIsNumeric _personCodeIsNumericMock;
        private ResourceManager _resourceManager;


        [SetUp]
        public void Setup()
        {
            _resourceManager = new ResourceManager("PersonCodeValidator.Tests.Resources.TestValidationMessages-en-US", Assembly.GetExecutingAssembly());
            _personCodeIsNumericMock = Substitute.For<PersonCodeIsNumeric>(_resourceManager);
            _personCodeValidatorService = new PersonCodeValidatorService(new List<IValidatable<PersonCode>>
            {
                _personCodeIsNumericMock
            }
            );
        }

        [Test]
        public void PersonCodeIsNumeric_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("V", "39507010451");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void PersonCodeIsNotNumeric_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("M", "4970828hhff");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("IsNotNumeric"), validationResult[0]);
        }
    }
}
