using System.Collections.Generic;

namespace dotnet_code_challenge.Models
{
    public class RaceDataSourceConfig
    {
        public IEnumerable<ConnectorConfig> Connections { get; set; }
    }
    
    public class ConnectorConfig
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}