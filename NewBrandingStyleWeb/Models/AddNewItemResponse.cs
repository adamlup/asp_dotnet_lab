using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBrandingStyleWeb.Models
{
    public class AddNewItemResponse<T>
    {
        public bool IsValid { get; set; }
        public string Content { get; set; }
        public T Data { get; set; }
    }
}
