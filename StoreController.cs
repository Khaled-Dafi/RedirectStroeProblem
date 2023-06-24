using Microsoft.AspNetCore.Mvc;

namespace IActionResutlExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books{id}")] //this is the new URL we need to redirect the old url BookStore to this URL 
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>This is Books Store{id}</h1>", "text/html");
        }
    }
}
