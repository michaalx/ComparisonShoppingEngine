using System;
using Logic.Functions;
using Business.Features;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Logic.Metadata;
using Logic.Database;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Store")]
    public class StoreController : Controller
    {
        private readonly ICheapest _cheapestStore;
        private readonly IDataModel _dataModel;

        public StoreController(ICheapest cheapestStore, IDataModel dataModel)
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
            var cheapestStore = _cheapestStore.GetCheapest(products);
            return cheapestStore;
        }
    }
}