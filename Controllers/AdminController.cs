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
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult TEMP()
        {
            AdminViewModel cvm = new AdminViewModel();
            DataLayer dal = new DataLayer();
            return View(new Customer());
        }
        public ActionResult Index()
        {
            AdminViewModel cvm = new AdminViewModel();
            DataLayer dal = new DataLayer();
            List<Product> objcus = dal.Products.ToList<Product>();
            List<Purchase> objcus1 = (from x in dal.Purchases select x).ToList(); 
            cvm.purchases = objcus1;
            //ProductViewModel cvm = new ProductViewModel();
            cvm.product = new Product();
            cvm.products = objcus;
            return View("Index", cvm);
        }
        public ActionResult GetAdminByJson() {
            DataLayer dal = new DataLayer();
           // Thread.Sleep(7000);
            List<Customer> objcus1 = (from x in dal.Customers where x.AdminVal == 1 select x).ToList();

            // List<Product> objcus = (from x in dal.Products select x).ToList();



            return Json(objcus1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowSearch()
        {
            AdminViewModel cvm = new AdminViewModel();
            DataLayer dal = new DataLayer();

            cvm.customers =  (from x in dal.Customers where x.AdminVal == 1  select x).ToList();

            return View("ShowAdmins", cvm);
        }

        //
        public ActionResult GetCustomerByJson()
        {
            DataLayer dal = new DataLayer();
            Thread.Sleep(7000);
            List<Product> objcus1 = dal.Products.ToList<Product>();

            List<Product> objcus = (from x in dal.Products select x).ToList();



            return Json(objcus1, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ShowAdmins() {
            AdminViewModel cvm = new AdminViewModel();
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
            return View("ShowAdmins", cvm);

        
    }

        public ActionResult Add_Admin() {
            AdminViewModel cvm = new AdminViewModel();
            DataLayer dal = new DataLayer();
            List<Product> objcus = dal.Products.ToList<Product>();
            List<Purchase> objcus1 = (from x in dal.Purchases select x).ToList();
            cvm.purchases = objcus1;
            List<Customer> objcus2 = (from x in dal.Customers where x.AdminVal==1 select x).ToList();
            Customer mycust = new Customer();

            mycust.ID = Request.Form["Admin.Id"].ToString();

            return View("Index",cvm);
        }

        public ActionResult Enter()
        {
            AdminViewModel cvm = new AdminViewModel();
            cvm.products = new List<Product>();
            DataLayer dal = new DataLayer();
            List<Product> objcu = (from x in dal.Products select x).ToList();
            List<Purchase> objcus = (from x in dal.Purchases select x).ToList(); ;
            cvm.purchases = objcus;

            //List<Product> objcus = dal.Products.ToList<Product>();
            cvm.product = new Product();
            cvm.products = objcu;
            return View("Index", cvm);

        }

        [HttpPost]
        public ActionResult History()
        {

            DataLayer dal = new DataLayer();
            List<Purchase> objcus = dal.Purchases.ToList<Purchase>();

            AdminViewModel cvm = new AdminViewModel();
            cvm = new AdminViewModel();
            cvm.purchase = new Purchase();
            cvm.purchases = objcus;
            return View("Index", cvm);

        }

        [HttpPost]
        public ActionResult Submit()
        {
            AdminViewModel cvm = new AdminViewModel();
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
            return View("Index", cvm);

        }
    }
}