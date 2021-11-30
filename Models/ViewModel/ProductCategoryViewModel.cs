using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTask.Models.ViewModel
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }
        public int ProdductId  { get; set; }

        [Required(ErrorMessage ="Please Enter Name.")]
        public string ProductName { get; set; }
        public IEnumerable<Product> Products { get; set; }


        public Category Category { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please Enter Name.")]
        public string CategoryName { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }

   
}