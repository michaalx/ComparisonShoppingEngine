using System;
using Logic.Functions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Metadata;
using Logic.Database;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Store")]
    public class CheapestController : Controller
    {
        public IActionResult GetCheapest(IEnumerable<string> products)
        {
           /* var products = new List<string>()
            {
                "Pienas",
                "Duona"
            };*/
            Tuple<Store, decimal> cheapestStore;
            CheapestStore cs = new CheapestStore();
            cheapestStore = cs.GetCheapestStore(products);
            return Ok(cheapestStore);
        }

        [HttpGet()]
        public IActionResult GetAllProducts()
        {
            var dm = new DataModel();
            var listToReturn = dm.GetAllStores();
            return Ok(listToReturn);
        }
    }
}