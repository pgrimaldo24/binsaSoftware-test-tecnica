using Microsoft.AspNetCore.Mvc;

namespace BinsaSoftware.ClientWebApp.Controllers
{
    public class CustomerContactController : Controller
    { 
        public CustomerContactController()
        {
        }

        public IActionResult CustomerContactView()
        {
            return View();
        } 
    }
}
