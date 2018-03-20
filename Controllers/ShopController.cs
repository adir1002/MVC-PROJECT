using ProjectN.Dal;
using ProjectN.Models;
using ProjectN.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ProjectN.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View("Enter",null);
        }



        public ActionResult Enter()
        {

            DataLayer dal = new DataLayer();
            List<Product> objcus = dal.Products.ToList<Product>();
            ProductViewModel cvm = new ProductViewModel();
            cvm.product = new Product();
            cvm.products = objcus;
            return View("Enter", cvm);

        }
        [HttpPost]
        public ActionResult Submit()
        {
            ProductViewModel cvm = new ProductViewModel();
            Product mycust = new Product();
            mycust.CatalogNumber = Request.Form["product.CatalogNumber"].ToString();
            mycust.Category = Request.Form["product.Category"].ToString();
            mycust.Name = Request.Form["product.Name"].ToString();
            mycust.Quantity = Int32.Parse(Request.Form["product.Quantity"].ToString());
            mycust.Price = Int32.Parse(Request.Form["product.Price"].ToString());
            mycust.Image = Request.Form["product.Image"].ToString();
            DataLayer dal = new DataLayer();

            if (ModelState.IsValid)
            {

                dal.Products.Add(mycust);
                dal.SaveChanges();
                cvm.product = new Product();
            }
            else
            {
                cvm.product = mycust;
            }

            cvm.products = dal.Products.ToList<Product>();
            return View("Enter", cvm);

        }

        public ActionResult ShowSearch()
        {
            AdminViewModel cvm = new AdminViewModel();
            cvm.products = new List<Product>();
            return View("SearchProduct", cvm);
        }
        public ActionResult SearchProduct()
        {
            DataLayer dal = new DataLayer();
          
           string SearchN = Request.Form["Text1"].ToString();
           //string SearchC = Request.Form["catalogtxt"].ToString();

            List<Product> objcu;
            if (SearchN == "Any")
            {
                objcu = (from x in dal.Products select x).ToList();
            }
            else
            {
                objcu = (from x in dal.Products where x.Name.Contains(SearchN) select x).ToList();
            }
            AdminViewModel cvm = new AdminViewModel();
            cvm.products = objcu;
            return View(cvm);

        }
    }
}