using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewBrandingStyleWeb.Database;
using NewBrandingStyleWeb.Entities;

namespace NewBrandingStyleWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {

        private readonly ExchangesDbContext _dbContext;

        public ItemController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AddNewItemResponse<DbSet<ItemEntity>> Post(ItemModel item)
        {
            bool success = !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.Name);
            string message = success ? "" : "Input fields cannot be empty";

            if (success)
            {
                var entity = new ItemEntity
                {
                    Name = item.Name,
                    Description = item.Description,
                    IsVisible = item.IsVisible
                };

                _dbContext.Items.Add(entity);
                _dbContext.SaveChanges();
            }

            var res = new AddNewItemResponse<DbSet<ItemEntity>>
            {
                IsValid = success,
                Content = message,
                Data = success ? _dbContext.Items : null
            };
            return res;
        }
    }
}
