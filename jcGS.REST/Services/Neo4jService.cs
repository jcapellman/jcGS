using jcGS.REST.Objects;

using Neo4jClient;

namespace jcGS.REST.Services
{
    public class Neo4jService
    {
        private GraphClient _client;

        public Neo4jService(DbConfig config)
        {
            _client = new GraphClient(new Uri(config.URL), config.Username, config.Password);            
        }

        public async Task<IEnumerable<NodeItem>> GetNodeAsync(Guid id, bool includeChildren = true)
        {
            if (!_client.IsConnected)
            {
                await _client.ConnectAsync();
            }

            return await _client.Cypher.Match("(node:Node)").Return(a => a.As<NodeItem>()).ResultsAsync;
        }
    }
}