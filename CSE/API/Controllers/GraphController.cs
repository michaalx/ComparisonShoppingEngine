using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Graph;
using Logic.Database;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Graph")]
    public class GraphController : Controller
    {
        private readonly IDataModel _dataModel;

        public GraphController(IDataModel dataModel) => _dataModel = dataModel;

        [HttpGet()]
        public IActionResult GetProducts(string item, int storeName)
        {
            //Item is product name, storeName is number of store in enum
            var go = new GraphOperations(item, storeName);
            var listToReturn = go.GetList();
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