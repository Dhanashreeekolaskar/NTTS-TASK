using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTask.Models;
using System.Linq.Dynamic;
namespace ProjectTask.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductInfo()
        {
            return View();
        }

        public ActionResult ProductList(JqDataTable model)
        {
            using (var _context = new ApplicationDbContext())
            {
                var productList = from product in _context.Products
                                  join Category in _context.Categories on product.CategoryId equals Category.CategoryId
                                  select new
                                  {
                                      ProductId = product.ProductId,
                                      ProductName = product.ProductName,
                                      CategoryId = Category.CategoryId,
                                      CategoryName = Category.CategoryName

                                  };

                var v = (from a in productList select a);

                var count = productList.Count();
                if (model.iSortCol_0 == 0 && model.sSortDir_0 == "asc")
                {
                    productList = productList.OrderBy(x => x.ProductId);
                }
                else if (model.iSortCol_0 == 0 && model.sSortDir_0 == "desc")
                {
                    productList = productList.OrderByDescending(x => x.ProductId);
                }


                if (model.iSortCol_0 == 1 && model.sSortDir_0 == "asc")
                {
                    productList = productList.OrderBy(x => x.ProductName);
                }
                else if (model.iSortCol_0 == 1 && model.sSortDir_0 == "desc")
                {
                    productList = productList.OrderByDescending(x => x.ProductName);
                }


                if (model.iSortCol_0 == 2 && model.sSortDir_0 == "asc")
                {
                    productList = productList.OrderBy(x => x.CategoryId);
                }
                else if (model.iSortCol_0 == 2 && model.sSortDir_0 == "desc")
                {
                    productList = productList.OrderByDescending(x => x.CategoryId);
                }



                if (model.iSortCol_0 == 2 && model.sSortDir_0 == "asc")
                {
                    productList = productList.OrderBy(x => x.CategoryName);
                }
                else if (model.iSortCol_0 == 2 && model.sSortDir_0 == "desc")
                {
                    productList = productList.OrderByDescending(x => x.CategoryName);
                }

                //Global Search functionality 

                if (!(string.IsNullOrEmpty(model.sSearch)) && !(string.IsNullOrWhiteSpace(model.sSearch)))
                {
                    productList = productList.Where(x => x.ProductName.Contains(model.sSearch) || x.CategoryName.Contains(model.sSearch));
                }






                var prolist = productList.Skip(model.iDisplayStart).Take(model.iDisplayLength).ToList();
                var result = new
                {
                    iTotalRecords = prolist.Count(),//records per page 
                    iTotalDisplayRecords = count, //total table count
                    aaData = prolist //employee list

                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
    }
}