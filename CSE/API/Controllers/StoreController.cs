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
        private readonly ICheapestStore _cheapestStore;
        private readonly IDataModel _dataModel;

        public CheapestController(ICheapestStore cheapestStore, IDataModel dataModel)
        {
            _cheapestStore = cheapestStore;
            _dataModel = dataModel;
        }

        [Route("api/Store/GetCheapest")]
        public IActionResult GetCheapest([FromBody]List<string> products)
        {
            Tuple<Store, decimal> cheapestStore;
            cheapestStore = _cheapestStore.GetCheapestStore(products);
            Store cheapest = cheapestStore.Item1;
            return Ok(cheapest);
        }

        [HttpGet()]
        public IActionResult GetAllProducts()
        {
            var listToReturn = _dataModel.GetAllStores();
            return Ok(listToReturn);
        }
    }
}