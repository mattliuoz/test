using System;
using dotnet_code_challenge.Connectors;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class RaceDataServiceTest
    {
        [Fact]
        public void RaceDataConnectorService_GetDataConnector_should_throw_NotSupportedException_when_racefield_is_not_supported()
        {
            var sut = new RaceDataConnectorService();
            Assert.Throws<NotSupportedException>(
                () => sut.GetDataConnector(RaceField.NotSupported)
            );
        }
        [Fact]
        public void RaceDataConnectorService_GetDataConnector_should_return_corresponding_data_connector_when_racefield_is_supported()
        {
            var sut = new RaceDataConnectorService();
            var dataConnector = sut.GetDataConnector(RaceField.Caulfield);
            Assert.IsType<CaulfieldRaceDataConnector>(dataConnector);
        }
    }
}
