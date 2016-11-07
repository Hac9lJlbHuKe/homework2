using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpecialTemplateSample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int count = 1;
        public string[] Name  { get; set; }
        public string[] note { get; set; }

    }
    public class Prod
    {
        
        public string Name { get; set; }
        public string note { get; set; }

    }
}