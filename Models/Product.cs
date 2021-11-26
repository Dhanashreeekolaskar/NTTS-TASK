using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTask.Models
{
    public class Product
    {
        public int ProductId  { get; set; }

        [Required]

        public string ProductName { get; set; }

        [Required]
        [Display(Name= "Category")]
        public int CategoryId { get; set; }
    }
}