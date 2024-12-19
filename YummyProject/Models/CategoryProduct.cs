using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class CategoryProduct
    {
        public IEnumerable<Category> ReachCategories { get; set; }

        public IEnumerable<Product> ReachProductsC1 { get; set; }
        public IEnumerable<Product> ReachProductsC2 { get; set; }
        public IEnumerable<Product> ReachProductsC3 { get; set; }
        public IEnumerable<Product> ReachProductsC4 { get; set; }

    }
}