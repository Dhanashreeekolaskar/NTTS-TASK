using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTask.Models;
using ProjectTask.Models.ViewModel;


namespace ProjectTask.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Category

        [HttpGet]
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);

        }


        [HttpGet]
        public ActionResult Form()
        {
           
            var viewModel = new ProductCategoryViewModel
            {
                Category = new Category(),
               

            };

            return View("CategoryForm", viewModel);
        }
           
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductCategoryViewModel
                {
                    Category = category
                };
                return View("CategoryForm",viewModel);
            }
            if (category.CategoryId==0)

                _context.Categories.Add(category);
            else
            {
                var categoryInDb = _context.Categories.Single(x => x.CategoryId == category.CategoryId);
                categoryInDb.CategoryName = category.CategoryName;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
            

        public ActionResult Edit(int Id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == Id);
            var viewModel = new ProductCategoryViewModel
            {
                Category = new Category(),


            };
            if (category == null)
                return HttpNotFound();
            return View("CategoryForm",viewModel);
        }


        




    }
}

