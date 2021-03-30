using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PersonCodeValidator.BusinessLogic;
using PersonCodeValidator.BusinessLogic.Vaildators;
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace PersonCodeValidator.UI
{
    class Program
    {

        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceBuilder = services.BuildServiceProvider();

            //Lyties įvedimas
            var genderParameter = serviceBuilder.GetService<IUI>().GetGenderParameterInput();

            // Asmens kodo įvedimas
            Console.WriteLine("Įveskite asmens kodą");
            var personCodeUserInput = Console.ReadLine();

            //Validacija
            var validationResult = serviceBuilder.GetService<IUI>().GetValidationResult(genderParameter, personCodeUserInput);

            foreach (var result in validationResult)
            {
                Console.WriteLine(result);
            }


        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IPersonCodeValidatorService, PersonCodeValidatorService>()
                .AddScoped<IUI, UI>()
                .AddSingleton<IPersonCodeValidatorService>(x => new PersonCodeValidatorService(new List<IValidatable<PersonCodeUserInput>> {
            new PersonCodeHasValidDate(),
            new PersonCodeHasValidGender(),
            new PersonCodeHasValidLength(),
            new PersonCodeIsNumeric()
        }
                    ));

            return services;
        }
    }
}
