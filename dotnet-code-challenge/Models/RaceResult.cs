using System;
using System.Collections.Generic;

namespace dotnet_code_challenge.Models
{
    public class RaceResult
    {
        public string TrackName { get; set; }
        public DateTime RaceDate { get; set; }
        public IEnumerable<HorseInRace> RaceHorseResults { get; set; }   
    }
}