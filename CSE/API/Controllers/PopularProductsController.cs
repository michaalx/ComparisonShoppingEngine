using Microsoft.AspNetCore.Mvc;
using LogicLibrary.Functions;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/PopularProducts")]
    public class PopularProductsController : Controller
    {
        private readonly IPopularProducts _popularProducts;
        public PopularProductsController(IPopularProducts popularProducts)
        {
            _popularProducts = popularProducts;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var listOfProducts =  _popularProducts.GetPopularProducts();
            return Ok(listOfProducts);
        }
    }
}