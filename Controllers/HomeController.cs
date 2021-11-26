using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using ProjectTask.Models;

namespace ProjectTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadData()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0] [dir]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                var Index = from Product in _context.Products
                                  join Category in _context.Categories on Product.CategoryId equals Category.CategoryId
                                  select new
                                  {
                                      ProductId = Product.ProductId,
                                      ProductName = Product.ProductName,
                                      CategoryId = Category.CategoryId,
                                      CategoryName = Category.CategoryName
                                  };

                var v = (from a in Index select a);

                if (!(string.IsNullOrEmpty(sortColumn )&& string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy(sortColumn + "" + sortColumnDir);
                }

                totalRecords = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new {draw, recordFiltered = totalRecords, recordsTotal = totalRecords, data }, JsonRequestBehavior.AllowGet);


            }
        }
    }
}