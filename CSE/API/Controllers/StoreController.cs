using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LogicCore.Functions;
using LogicCore.Database;
using LogicCore.Metadata;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Store")]
    public class StoreController : Controller
    {
        private readonly ICheapestStore _cheapestStore;
        private readonly IDataModel _dataModel;

        public StoreController(ICheapestStore cheapestStore, IDataModel dataModel)
        {
            _cheapestStore = cheapestStore;
            _dataModel = dataModel;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var listToReturn = _dataModel.GetAllStores();
            return Ok(listToReturn);
        }

        [HttpPost]
        public Dictionary<string, decimal> PostProducts([FromBody]List<string> products)
        {
            Tuple<Store, decimal> cheapestStore;
            cheapestStore = _cheapestStore.GetCheapestStore(products);
            var cheapest = new Dictionary<string, decimal>();
            cheapest.Add(cheapestStore.Item1.ToString(), cheapestStore.Item2);
            return cheapest;
        }
    }
}