using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebAppJQ.Models;

namespace WebAppJQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();
            CustomerEntities entities = new CustomerEntities();
            return View(from customer in entities.Customers
                        select customer);
        }
        [HttpPost]
        public ActionResult Details(int custID)
        {
            CustomerEntities entities = new CustomerEntities();
            return PartialView("Details", entities.Customers.Find(custID));
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}