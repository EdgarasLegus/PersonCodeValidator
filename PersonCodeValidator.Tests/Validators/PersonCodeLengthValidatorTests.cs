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
    public class PersonCodeLengthValidatorTests
    {
        private IPersonCodeValidatorService _personCodeValidatorService;
        private PersonCodeHasValidLength _personCodeHasValidLengthMock;
        private ResourceManager _resourceManager;


        [SetUp]
        public void Setup()
        {
            _resourceManager = new ResourceManager("PersonCodeValidator.Tests.Resources.TestValidationMessages-en-US", Assembly.GetExecutingAssembly());
            _personCodeHasValidLengthMock = Substitute.For<PersonCodeHasValidLength>(_resourceManager);
            _personCodeValidatorService = new PersonCodeValidatorService(new List<IValidatable<PersonCode>>
            {
                _personCodeHasValidLengthMock
            }
            );
        }

        [Test]
        public void ValidPersonCodeLength_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("V", "39507010451");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void InvalidPersonCodeLength_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("M", "5040101666446797979");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("LengthIsNotValid"), validationResult[0]);
        }

        [Test]
        public void InvalidPersonCodeLength_ShouldThrowException()
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new PersonCode("M", "504"));
        }
    }
}
