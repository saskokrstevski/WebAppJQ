using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebAppJQ.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult ListCompany()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            
                items.Add(new SelectListItem { Text = "PPG", Value = "0" });

                items.Add(new SelectListItem { Text = "DC", Value = "1" });

                items.Add(new SelectListItem { Text = "MGM", Value = "2", Selected = true });

            
            ViewBag.Company = items;

            return View();

        }
        public ActionResult About()
        {
            //return View();
            CustomerEntities entities1 = new CustomerEntities();
            return View(from customer in entities1.Customers
                        select customer);

            
        }

        [HttpGet]
        public ActionResult CustomerBox(string Value)
        {
            List<Customer> customer = new List<Customer>();
         

            var queryCustomer = from _customer in customer
                             where _customer.city == Value
                             select _customer;

            return PartialView("CustomerBox", queryCustomer);
        }
    }
}