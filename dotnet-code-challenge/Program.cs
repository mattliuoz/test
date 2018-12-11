using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    class Program
    {

        public static string RaceTrack
        {
            get;
            set;
        }

        public static void Main(string [] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional : true, reloadOnChange : true);

            IConfigurationRoot configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddScoped<IRaceService, RaceService>()
                .AddScoped<IRaceDataConnectorService, RaceDataConnectorService>()
                .Configure<RaceDataSourceConfig>(options => configuration.GetSection("raceDataSource"))
                .BuildServiceProvider();
            var raceService = serviceProvider.GetService<IRaceService>();
            var app = new CommandLineApplication();
            app.Name = "horses";
            app.HelpOption("-?|-h|--help");

            app.Command("horses", (command) =>
            {
                SetUpCommand(command, raceService);
            });

            try
            {
                Environment.Exit(app.Execute(args));
            }
            catch (Exception ex)
            {
                ExitOnError($"Horses stopped because of error:{ex.Message}.");
            }

        }
        static void ExitOnError(string errorMessage)
        {
            //notes: we can log error here
            Environment.Exit(2);
        }
        private static void SetUpCommand(CommandLineApplication command, IRaceService raceService)
        {
            var raceTrackOption = command.Option("-r", "Race track", CommandOptionType.SingleValue);

            command.Description = "Get horses";
            command.OnExecute(async() =>
            {
                if (IsSet(raceTrackOption, true))
                {
                    RaceTrack = raceTrackOption.Value();
                }

                await GetHorses(raceService);

                return 0;
            });
        }

        static bool IsSet(CommandOption option, bool isOptional = false)
        {
            if (!option.HasValue())
            {
                if (!isOptional)
                {
                    Console.WriteLine($"must specify '{option.Description}'");
                }

                return false;
            }

            return true;
        }
        private static async Task GetHorses(IRaceService raceService)
        {
            //Notes: I would impelemnt some validation logic against user input if I have more time
            RaceField raceTrackValue;
            if (!Enum.TryParse(RaceTrack, true, out raceTrackValue))
            {
                throw new Exception($"Race track {raceTrackValue} is not supported");
            }
            var raceResult = await raceService.GetRaceResult(raceTrackValue);
            var sortedHorseResult = raceResult.RaceHorseResults.OrderBy(horse => horse.Price).ToArray();
            Console.WriteLine("Below shows all horses for race at {} on track {}, order by price:");

            foreach (var horse in sortedHorseResult)
            {
                Console.WriteLine($"{horse.Name}, price {horse.Price}, jockey {horse.JockeyName}");
            }
        }

    }
}