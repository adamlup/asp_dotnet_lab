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
            bool success = !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.Name);
            string message = success ? "" : "Input fields cannot be empty";
            var res = new AddNewItemResponse
            {
                IsValid = success,
                Content = success ? "" : message
            };
            return res;
        }
    }
}
