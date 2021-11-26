using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTask.Models
{
    public class MyDbContext
    {
        public List<Product> Products { get; set; }

        public List <Category>Categories { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }
}