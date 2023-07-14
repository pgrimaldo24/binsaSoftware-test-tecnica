using Microsoft.AspNetCore.Mvc;

namespace BinsaSoftware.ClientWebApp.Controllers
{
    public class ClientController : Controller
    { 
        public ClientController()
        {
        }

        public IActionResult ListClientView()
        {
            return View();
        }

        public IActionResult PopupNewCustomer()
        {
            return View();
        }

        public IActionResult PopupEditCustomer(int id)
        {
            ViewBag.id = id;
            return View(); 
        }
            
        public IActionResult PopupDeleteCustomer(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
