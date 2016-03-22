using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shasta_Water_Management.Models;
using Shasta_Water_Management.Repositories;

namespace Shasta_Water_Management.Controllers
{
    public class CustomerController : Controller
    {
        /// <summary>
        /// Gets all Customers
        /// </summary>
        /// <returns>JSON List of Customers</returns>
        [HttpGet]
        public ActionResult GetCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>();

            customers = CustomerRepository.GetCustomers();

            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Brings up the customer profile page
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Search(string id)
        {
            var customer = new Customer();

            customer = CustomerRepository.GetCustomer(id);

            return View("CustomerProfile", customer);
        }

        [HttpGet]
        public ActionResult EditCustomer(string id)
        {
            var customer = new Customer();

            customer = CustomerRepository.GetCustomer(id);
            ViewBag.Method = "Edit";

            return View("CustomerForm", customer);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            ViewBag.Method = "Add";

            return View("CustomerForm");
        }
    }
}