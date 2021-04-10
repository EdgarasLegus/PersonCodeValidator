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
    public class PersonCodeGenderAndDateRelationValidatorTests
    {
        private IPersonCodeValidatorService _personCodeValidatorService;
        private PersonCodeHasValidGenderAndDateRelation _personCodeHasValidGenderAndDateRelationMock;
        private ResourceManager _resourceManager;


        [SetUp]
        public void Setup()
        {
            _resourceManager = new ResourceManager("PersonCodeValidator.Tests.Resources.TestValidationMessages-en-US", Assembly.GetExecutingAssembly());
            _personCodeHasValidGenderAndDateRelationMock = Substitute.For<PersonCodeHasValidGenderAndDateRelation>(_resourceManager);
            _personCodeValidatorService = new PersonCodeValidatorService(new List<IValidatable<PersonCode>>
            {
                _personCodeHasValidGenderAndDateRelationMock
            }
            );
        }

        [Test]
        public void ValidBirthDateAndGenderRelationForMale_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("V", "38812130041");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ValidBirthDateAndGenderRelationForFemale_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("M", "47110090001");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ValidBirthDateAndGenderRelationForMaleBornThisMillenium_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("V", "50110090001");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ValidBirthDateAndGenderRelationForFemaleBornThisMillenium_ShouldNotHaveValidationErros()
        {
            //Arrange
            var personCode = new PersonCode("M", "60711194651");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void InvalidBirthDateAndGenderRelationMale_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("V", "30602200081");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("DateAndGenderRelationIsInvalid"), validationResult[0]);
        }

        [Test]
        public void InvalidBirthDateAndGenderRelationMaleBornThisMillenium_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("V", "59604145781");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("DateAndGenderRelationIsInvalid"), validationResult[0]);
        }

        [Test]
        public void InvalidBirthDateAndGenderRelationFemale_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("M", "40609194781");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("DateAndGenderRelationIsInvalid"), validationResult[0]);
        }

        [Test]
        public void InvalidBirthDateAndGenderRelationFemaleBornThisMillenium_ShouldHaveValidationError()
        {
            //Arrange
            var personCode = new PersonCode("M", "69604145781");

            //Act
            var validationResult = _personCodeValidatorService.Validate(personCode).ToList();

            //Assert
            Assert.AreEqual(_resourceManager.GetString("DateAndGenderRelationIsInvalid"), validationResult[0]);
        }
    }
}
