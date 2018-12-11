using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Services
{
    /*
    Notes: There's no specific reason why I am putting both interface 
    and concrete class in the same file, it can be in separate files 
    depending on team's preference. 
    */
    public interface IRaceService
    {
        Task<RaceResult> GetRaceResult(RaceField raceField);
    }

    public class RaceService : IRaceService
    {
        private readonly IRaceDataConnectorService _raceDataConnectorService;
        public RaceService(IRaceDataConnectorService raceDataConnectorService)
        {
            _raceDataConnectorService = raceDataConnectorService;
        }
        public async Task<RaceResult> GetRaceResult(RaceField raceField)
        {
            var connector = _raceDataConnectorService.GetDataConnector(raceField);
            var raceResult = await connector.GetRaceResult();
            return raceResult;
        }

    }
}