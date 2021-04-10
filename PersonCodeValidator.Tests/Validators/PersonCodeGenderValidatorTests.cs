using NSubstitute;
using NUnit.Framework;
using PersonCodeValidator.BusinessLogic;
using PersonCodeValidator.BusinessLogic.Vaildators;
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace PersonCodeValidator.Tests
{
    public class PersonCodeGenderValidatorTests
    {
        private IPersonCodeValidatorService _personCodeValidatorService;
        private PersonCodeHasValidGender _personCodeHasValidGenderMock;
        private ResourceManager _resourceManager;


        [SetUp]
        public void Setup()
        {
            _resourceManager = new ResourceManager("PersonCodeValidator.Tests.Resources.TestValidationMessages-en-US", Assembly.GetExecutingAssembly());
            _personCodeHasValidGenderMock = Substitute.For<PersonCodeHasValidGender>(_resourceManager);
            _personCodeValidatorService = new PersonCodeValidatorService(new List<IValidatable<PersonCode>>
            {
                _personCodeHasValidGenderMock
            }
            );
        }

        [Test]
        public void ValidMaleGender_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("V", "39507010451");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ValidFemaleGender_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("M", "49102010347");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ValidFemaleBornThisMilleniumGender_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("M", "60107010583");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ValidMaleBornThisMilleniumGender_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("V", "50406214489");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void InvalidMaleGender_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("V", "49602270081");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("GenderIsNotValid"), validationResult[0]);
        }

        [Test]
        public void InvalidFemaleGender_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("M", "50605280071");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("GenderIsNotValid"), validationResult[0]);
        }

    }
}
