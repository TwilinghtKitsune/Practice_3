using Practice_3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_3.Controllers
{
    public class HomeController : Controller
    {
        Orders_and_customersContext db = new Orders_and_customersContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Customers);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            Customer b = db.Customers.Find(id);
            if (b != null)
            {
                db.Customers.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult InOrder()
        {
            return View("Orders", db.Orders);
        }

        [HttpGet]
        public ViewResult InCustomer()
        {
            return View("Index", db.Customers);
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                return View(order);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return View("Orders", db.Orders);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return View("Orders", db.Orders);
        }

        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            Order b = db.Orders.Find(id);
            if (b != null)
            {
                db.Orders.Remove(b);
                db.SaveChanges();
            }
            return View("Orders", db.Orders);
        }
    }
}