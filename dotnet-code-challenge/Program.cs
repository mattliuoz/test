using System;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    class Program
    {
        private readonly IHorseService _horseService;

        public static int Main(string [] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IHorseService, HorseService>()
                .AddScoped<IRaceDataConnectorService, RaceDataConnectorService>()
                .BuildServiceProvider();

            var app = new CommandLineApplication<Program>();
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);

            return app.Execute(args);
        }

        public Program(IHorseService horseService)
        {
            _horseService = horseService;
        }

        private void OnExecute()
        {
            _horseService.GetHorses(RaceField.Caulfield);
        }
    }
}