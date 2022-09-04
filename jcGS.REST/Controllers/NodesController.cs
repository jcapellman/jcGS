using jcGS.REST.Objects;
using jcGS.REST.Services;

using Microsoft.AspNetCore.Mvc;

namespace jcGS.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NodesController : ControllerBase
    {
        private readonly ILogger<NodesController> _logger;

        private readonly Neo4jService _neoService;

        public NodesController(ILogger<NodesController> logger, Neo4jService graphClient)
        {
            _logger = logger;
            _neoService = graphClient;
        }

        [HttpGet]
        public async Task<IEnumerable<NodeItem>> GetAsync(string id, bool includeChildren = true) => await _neoService.GetNodeAsync(Guid.NewGuid(), includeChildren);
    }
}