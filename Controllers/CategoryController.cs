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
        public ActionResult CategoryForm()
        {




            return View();


        }



        [HttpPost]

        public ActionResult Save(Category category)
        {
                _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
            

            

        

        public ActionResult Edit(int Id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == Id);

            if (category == null)
                return HttpNotFound();

            

            return View("CategoryForm",category);
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Category category = _context.Categories.Find(Id);
            _context.Categories.Remove(category);
            
            _context.SaveChanges();

            return RedirectToAction("Index", category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {

            _context.Categories.Remove(category);
            _context.SaveChanges();


            return RedirectToAction("Index",category);

        }




    }
}

