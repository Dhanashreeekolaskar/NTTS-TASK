﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTask.Models.ViewModel
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }

        public Category Category { get; set; }


        public IEnumerable<Category> Categories { get; set; }
    }
}