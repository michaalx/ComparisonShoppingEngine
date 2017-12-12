using Microsoft.AspNetCore.Mvc;
using LogicCore.Database;
using LogicCore.Graph;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Graph")]
    public class GraphController : Controller
    {
        private readonly IDataModel _dataModel;
        private readonly IGraphOperations _graphOperations;

        public GraphController(IGraphOperations graphOperations, IDataModel dataModel)
        {
            _dataModel = dataModel;
            _graphOperations = graphOperations;
        }

        [HttpGet()]
        public IActionResult GetProducts(string item, int storeName)
        {
            //Dependency Injection (new approach).   
            _graphOperations.SetItem(item);
            _graphOperations.SetStoreName(storeName);
            var listToReturn = _graphOperations.GetList();

            //Item is product name, storeName is number of store in enum
            //var go = new GraphOperations(item, storeName);
            // var listToReturn = go.GetList();
            return Ok(listToReturn);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetOneStore(int id)
        {
            var listToReturn = _dataModel.OneStore(id);
            return Ok(listToReturn);
        }
    }
}