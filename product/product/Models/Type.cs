using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace product.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public int ProductId { get; set; }
        public string categoria { get; set; }
        public string colour { get; set; }
    }
}