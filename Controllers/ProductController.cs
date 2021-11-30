using ProjectTask.Models;
using System.Linq;
using System.Web.Mvc;
using ProjectTask.Models.ViewModel;

namespace ProjectTask.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get Product
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
        


            return View(products);
        }

       

        [HttpGet]
        public ActionResult ProductForm( )
        {
            var category = _context.Categories.ToList();
            var viewModel = new ProductCategoryViewModel
            {
                Product = new Product(),
                Categories = category
           
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductCategoryViewModel
                {
                    Product = product,
                    Categories = _context.Categories.ToList()
                };

                return View("ProductForm",viewModel);
            }
            if (product.ProductId==0)

            _context.Products.Add(product);
            else
            {
                var productInDb = _context.Products.Single(x => x.ProductId == product.ProductId);

                productInDb.ProductName = product.ProductName;
                productInDb.CategoryId = product.CategoryId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = _context.Products.SingleOrDefault(x => x.ProductId == Id);

            if(product == null)
            return HttpNotFound();

            var viewModel = new ProductCategoryViewModel
            { 
                Product = product,
                Categories = _context.Categories.ToList()
            };

            return View("ProductForm", viewModel);
        }

        
     [HttpGet]
     public ActionResult Delete(int Id)
        {
            Product product = _context.Products.Find(Id);
            _context.Products.Remove(product);
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {

            _context.Products.Remove(product);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }

        
    }


    
}