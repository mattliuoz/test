using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Connectors
{
    public abstract class RaceDataConnector
    {
        /*Notes: Perhaps more filtering fields can be passed from here
        i.e. GetRaceResult(DateTime raceDate)
         so that it can be more useful, but I am not putting any here since not seeing any usecase as yet.
        */
        public abstract Task<RaceResult> GetRaceResult();

        public RaceDataConnector(RaceDataSourceConfig config)
        {
            _config=config;
        }
        private  readonly RaceDataSourceConfig _config;
    }


}