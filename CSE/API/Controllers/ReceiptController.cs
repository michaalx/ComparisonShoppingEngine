using Microsoft.AspNetCore.Mvc;
using Logic.DataManagement;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

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
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task Post(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var fileBytes = new byte[file.Length];
                await stream.ReadAsync(fileBytes, 0, (int)file.Length);
                try
                {
                    _converter.SaveReceipt(fileBytes);
                }
                catch(Exception e)
                {

                }
            }
        }
    }
}