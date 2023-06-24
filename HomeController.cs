using Microsoft.AspNetCore.Mvc;

namespace IActionResutlExample.Controllers
{
    public class HomeController : Controller
    {
        //this is the main URL that we will change

        [Route("BookStore")] //we will redirect to store/book
        public IActionResult Index()
        {
            if(!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("books not supply");

            }
            
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
                
            {
                return BadRequest("BOOK ID CAN'T BE EMPTY OR NULL ");
            }

            int bookid = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]); //to read content form the url

            if(bookid <= 0) {


                return BadRequest("Bookid cannot be less then zero ");
            }
            if (bookid > 1000) {

                return NotFound("book id cannot be more then 1000");
            
            }

            if (Convert.ToBoolean(Request.Query["isLoggin"]) == false)
            {
                
                return Unauthorized("User must be athentaicted ");
            }


            return RedirectToAction("Books", "Store", new {id = bookid});

             
              //for redeircting to the new URL 
              return new RedirectToActionResult("Books", "Store", new {}, permanent: true);  //namles object

        }
    }
}
