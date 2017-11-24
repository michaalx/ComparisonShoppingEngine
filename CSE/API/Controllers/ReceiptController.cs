using Microsoft.AspNetCore.Mvc;
using Logic.DataManagement;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Receipt")]
    public class ReceiptController : Controller
    {
        private readonly IConverter _converter;

        public ReceiptController(IConverter converter) => _converter = converter;

        /// <summary>
        /// Method which is called when an image of 
        /// receipt is uploaded.
        /// Should be changed to HttpPost.
        /// </summary>
        /// <param name="image"></param>
        [HttpGet]
        public void Post(byte[] image)
        {
            _converter.SaveReceipt(image);
            return;
        }
    }
}