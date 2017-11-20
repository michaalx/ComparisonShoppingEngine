using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Graph")]
    public class GraphController : Controller
    {
        [HttpGet]
        public JsonResult GetProducts()
        {
            return new JsonResult(new List<object>
            {
                new { id=1, Name="as"},
                new { id=2, Name="tu"}
            });
        }
    }
}