using Microsoft.AspNetCore.Mvc;
using NewBrandingStyleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBrandingStyleWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {

        public AddNewItemResponse Post(ItemModel item)
        {
            bool isString = !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.Name);
            var response = new AddNewItemResponse
            {
                IsValid = isString,
                Content = isString ? "" : "Input fields cannot be empty"
            };
            return response;
        }
    }
}
