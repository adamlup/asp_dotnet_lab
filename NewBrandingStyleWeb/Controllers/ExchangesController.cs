using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Database;
using NewBrandingStyleWeb.Entities;
using NewBrandingStyleWeb.Filters;
using NewBrandingStyleWeb.Models;

namespace NewBrandingStyleWeb.Controllers
{
    public class ExchangesController : Controller
    {
        private readonly ExchangesDbContext _dbContext;

        public ExchangesController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ServiceFilter(typeof(MyCustomActionFilter))]
        public IActionResult Show(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            return RedirectToAction("AddConfirmation");
        }

        [HttpGet]
        public IActionResult AddConfirmation()
        {
            ViewBag.Items = _dbContext.Items;
            return View();
        }
    }
}
