using System;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class RaceServiceTest
    {
        [Fact]
        public void RaceService_GetRaceResult_should_throw_NotSupportedException_when_racefield_is_not_supported()
        {
            var sut = new RaceDataConnectorService();
            Assert.Throws<NotSupportedException>(
                () => sut.GetDataConnector(RaceField.NotSupported)
            );
        }

        [Fact]
        public void RaceService_GetRaceResult_should_return_raceResult_when_racefield_is_supported()
        {
            var raceDataConnectorService = new RaceDataConnectorService();
            
            var sut = new RaceService(raceDataConnectorService);
            var raceResult = sut.GetRaceResult(RaceField.Caulfield);
            Assert.NotEmpty(raceResult.RaceHorseResults);
        }
    }
}
