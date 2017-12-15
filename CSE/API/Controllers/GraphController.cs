using Business.Features;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Graph")]
    public class GraphController : Controller
    {
        private readonly IGraphData _graphData;
        private readonly IGraphOperations _graphOperations;

        /*private readonly IDataModel _dataModel;
        private readonly IGraphOperations _graphOperations;
        */
        public GraphController(IGraphData graphData, IGraphOperations graphOperations)
        {
            _graphData = graphData;
            _graphOperations = graphOperations;
        }

        [HttpGet()]
        public IActionResult GetProducts(string item, int storeNum)
        {
            _graphOperations.SetItem(item);
            _graphOperations.SetStoreName(storeNum);

            var result = _graphOperations.GetList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneStore(int id)
        {
            var result = _graphData.GetProducts(id);
            return Ok(result);
        }
        
    }
}