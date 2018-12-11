using System.Collections.Generic;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Connectors
{
    public interface IRaceDataConnector
    {
        /*Notes: Perhaps more filtering fields can be passed from here
        i.e. GetRaceResult(DateTime raceDate)
         so that it can be more useful, but I am not putting any here since not seeing any usecase as yet.
        */
        RaceResult GetRaceResult();
    }

    public class CaulfieldRaceDataConnector : IRaceDataConnector
    {
        public RaceResult GetRaceResult()
        {
            throw new System.NotImplementedException();
        }
    }

    public class WolferhamptonRaceDataConnector : IRaceDataConnector
    {
        public RaceResult GetRaceResult()
        {
            throw new System.NotImplementedException();
        }
    }
}