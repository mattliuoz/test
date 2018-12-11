using System;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    class Program
    {
        private readonly IRaceService _raceService;

        public static int Main(string [] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IRaceService, RaceService>()
                .AddScoped<IRaceDataConnectorService, RaceDataConnectorService>()
                .BuildServiceProvider();

            var app = new CommandLineApplication<Program>();
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);

            return app.Execute(args);
        }

        public Program(IRaceService raceService)
        {
            _raceService = raceService;
        }

        private void OnExecute()
        {
            _raceService.GetRaceResult(RaceField.Caulfield);
        }
    }
}