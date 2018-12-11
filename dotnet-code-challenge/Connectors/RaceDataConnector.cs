using System.Collections.Generic;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Connectors
{
    public interface IRaceDataConnector
    {
        IEnumerable<RaceResult> GetRaceResult();
    }

    public class CaulfieldRaceDataConnector : IRaceDataConnector
    {
        public IEnumerable<RaceResult> GetRaceResult()
        {
            throw new System.NotImplementedException();
        }
    }

    public class WolferhamptonRaceDataConnector : IRaceDataConnector
    {
        public IEnumerable<RaceResult> GetRaceResult()
        {
            throw new System.NotImplementedException();
        }
    }
}