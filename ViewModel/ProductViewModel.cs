using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectN.Models;

namespace ProjectN.ViewModel
{
    public class ProductViewModel
    {
        public Product product { get; set; }

        public List<Product> products { get; set; }
    }
}