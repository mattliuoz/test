using System;
using dotnet_code_challenge.Connectors;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Services
{
    public interface IRaceDataConnectorService
    {
        IRaceDataConnector GetDataConnector(RaceField raceField);
    }
    public class RaceDataConnectorService : IRaceDataConnectorService
    {
        public IRaceDataConnector GetDataConnector(RaceField raceField)
        {
            if(raceField == RaceField.Caulfield)
            {
                return new CaulfieldRaceDataConnector();
            }

            if(raceField == RaceField.Wolferhampton)
            {
                return new WolferhamptonRaceDataConnector();
            }

            throw new NotSupportedException($"{raceField.ToString()} does not have any data connector.");
        }
    }
}