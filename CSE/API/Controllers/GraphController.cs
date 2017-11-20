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
        public IActionResult GetProducts(string item)
        {
            GraphOperations go = new GraphOperations(item);
            var listToReturn = go.GetList();
            return Ok(listToReturn);
        }
    }
}