using System;
using System.Linq;
using dotnet_code_challenge.Connectors;
using dotnet_code_challenge.Models;
using Microsoft.Extensions.Options;

namespace dotnet_code_challenge.Services
{
    public interface IRaceDataConnectorService
    {
        RaceDataConnector GetDataConnector(RaceField raceField);
    }
    public class RaceDataConnectorService : IRaceDataConnectorService
    {
        private readonly IOptions<RaceDataSourceConfig> _config;
        public RaceDataConnectorService(IOptions<RaceDataSourceConfig> config)
        {
            _config = config;
        }
        public RaceDataConnector GetDataConnector(RaceField raceField)
        {
            if (raceField == RaceField.Caulfield)
            {
                return new CaulfieldRaceDataConnector(_config.Value);
            }

            if (raceField == RaceField.Wolferhampton)
            {
                return new WolferhamptonRaceDataConnector(_config.Value);
            }

            throw new NotSupportedException($"{raceField.ToString()} does not have any data connector.");
        }
    }
}