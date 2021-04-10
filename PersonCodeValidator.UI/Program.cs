using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PersonCodeValidator.BusinessLogic;
using PersonCodeValidator.BusinessLogic.Vaildators;
using PersonCodeValidator.BusinessLogic.Validators;
using PersonCodeValidator.Contracts.Entities;
using PersonCodeValidator.Data.Settings;
using PersonCodeValidator.Interfaces;
using PersonCodeValidator.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace PersonCodeValidator.UI
{
    class Program
    {

        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceBuilder = services.BuildServiceProvider();

            //Lyties įvedimas
            var genderParameter = serviceBuilder.GetService<IUserInterface>().GetGenderParameterInput();

            // Asmens kodo įvedimas
            Console.WriteLine("Įveskite asmens kodą");
            var personCodeUserInput = Console.ReadLine();

            //Validacija
            var validationResult = serviceBuilder.GetService<IUserInterface>().GetValidationResult(genderParameter, personCodeUserInput);

            foreach (var result in validationResult)
            {
                Console.WriteLine(result);
            }


        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            ResourceManager resourceManager = new ResourceManager("PersonCodeValidator.UI.Resources.ValidationMessages-EN", Assembly.GetExecutingAssembly());

            services.Configure<ResourcesConfig>(options => configuration.GetSection("ResourcesConfig").Bind(options));


            services.AddScoped<IPersonCodeValidatorService, PersonCodeValidatorService>()
                .AddScoped<IUserInterface, UserInterface>()
                .AddSingleton<IPersonCodeValidatorService>(x => new PersonCodeValidatorService(new List<IValidatable<PersonCode>> {
            new PersonCodeHasValidDate(resourceManager),
            new PersonCodeHasValidGender(resourceManager),
            new PersonCodeHasValidLength(resourceManager),
            new PersonCodeIsNumeric(resourceManager),
            new PersonCodeHasValidGenderAndDateRelation(resourceManager)
        }
                    ));

            return services;
        }
    }
}
