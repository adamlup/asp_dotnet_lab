using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Models;

namespace NewBrandingStyleWeb.Controllers
{
    public class ActionController : Controller
    {
        public IActionResult Show(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ItemModel item)
        {
            var viewModel = new NewItemAddedViewModel
            {
                Id = 1,
                Name = item.Name,
            };

            return RedirectToAction("AddConfirmation");
        }

        [HttpGet]
        public IActionResult AddConfirmation()
        {
            return View();
        }
    }
}
