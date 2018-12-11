using System;
using System.Linq;
using System.Threading.Tasks;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Connectors
{
    public class WolferhamptonRaceDataConnector : RaceDataConnector
    {
        private readonly RaceDataSourceConfig _config;
        const string RACE_FIELD_NAME = "Wolferhampton";
        public WolferhamptonRaceDataConnector(RaceDataSourceConfig config) : base(config)
        {
            _config = config;
        }

        //Notes: get race data can be asyn, I don't have time to do it
        public override async Task<RaceResult> GetRaceResult()
        {
            var caulfieldConfig = _config.Connections.FirstOrDefault(config => config.Name.Equals(RACE_FIELD_NAME, StringComparison.OrdinalIgnoreCase));
            
            if (caulfieldConfig == null)
            {
                throw new Exception($"Connection configuration for {RACE_FIELD_NAME}");
            }

            var url = caulfieldConfig.Uri;
            //Get race data
            throw new System.NotImplementedException();
        }
    }
}