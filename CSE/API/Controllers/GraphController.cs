using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Graph;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Graph")]
    public class GraphController : Controller
    {
        [HttpGet()]
        public IActionResult GetProducts(string item, int storeName)
        {
            //Item is product name, storeName is number of store in enum
            GraphOperations go = new GraphOperations(item, storeName);
            var listToReturn = go.GetList();
            return Ok(listToReturn);
        }
    }
}