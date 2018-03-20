using ProjectN.Dal;
using ProjectN.Models;
using ProjectN.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }


        public ActionResult EnterPartial()
        {
            DataLayer dal = new DataLayer();
            List<Product> objcus = dal.Products.ToList();

            ProductViewModel cvm = new ProductViewModel();
            cvm.product = new Product();
            cvm.products = objcus;
            return View(cvm);
        }

        public ActionResult ShowSearch()
        {
            ProductViewModel cvm = new ProductViewModel();
            cvm.products = new List<Product>();
            return View("Searchproduc", cvm);
        }
        public ActionResult Searchproduct()
        {
            DataLayer dal = new DataLayer();
            string SearchF = Request.Form["txtName"].ToString();
            List<Product> objcu = (from x in dal.Products where x.Name.Contains(SearchF) select x).ToList<Product>();
            ProductViewModel cvm = new ProductViewModel();
            cvm.products = objcu;
            return View(cvm);

        }
        public ActionResult Authenticate(Customer admn, string returnUrl)
        {
            DataLayer dal = new DataLayer();

            ViewBag.Title = "Home Page";

            // Code to check if user == password and exists on DB
            // Transfer to Homepage
            List<Customer> adminValidated = (from a in dal.Customers
                                             where (a.UserName == admn.UserName) && (a.Password == admn.Password)
                                          select a).ToList<Customer>();

            if (/*adminValidated.Count == 1*/true)
            {
                // User Authenticated Successfully
                admn = adminValidated[0];
                Session["CurrentAdmin"] = admn;
                FormsAuthentication.SetAuthCookie(admn.ID, true);

                if (returnUrl != null)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                //TempData["WrongLogin"] = true;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            ViewBag.Title = "Home Page";
            return RedirectToLocal("Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}