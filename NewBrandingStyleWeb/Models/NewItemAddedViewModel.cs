using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBrandingStyleWeb.Models
{
    public class NewItemAddedViewModel
    {
        public int NumberOfCharInName { get; set; }
        public int NumberOfCharsInDescription { get; set; }
        public bool IsHidden { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
