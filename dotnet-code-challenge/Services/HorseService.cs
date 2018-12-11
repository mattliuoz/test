using System.Collections.Generic;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Services
{
    /*
    Notes: There's no specific reason why I am putting both interface 
    and concrete class in the same file, it can be in separate files 
    depending on team's preference. 
    */
    public interface IHorseService
    {
        IEnumerable<Horse> GetHorses(RaceField raceField);
    }
    
    public class HorseService : IHorseService
    {
        public IEnumerable<Horse> GetHorses(RaceField raceField)
        {
            throw new System.NotImplementedException();
        }
    }
}