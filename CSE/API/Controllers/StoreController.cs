
using Business.Features;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Store")]
    public class StoreController : Controller
    {
        private readonly ICheapest _cheapestStore;

        public StoreController(ICheapest cheapestStore)
        {
            _cheapestStore = cheapestStore;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var listToReturn = _cheapestStore.GetProducts();
            return Ok(listToReturn);
        }

        [HttpPost]
        public Dictionary<string, decimal> PostProducts([FromBody]List<string> products)
        {
            var cheapestStore = _cheapestStore.GetCheapest(products);
            return cheapestStore;
        }
    }
}