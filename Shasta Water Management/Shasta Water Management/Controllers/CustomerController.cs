using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shasta_Water_Management.Models;
using Shasta_Water_Management.Properties;
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
        /// Get the customers who need to be serviced
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUpcomingServiceCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>();

            customers =
                CustomerRepository.GetCustomers()
                    .Where(x => Convert.ToDateTime(x.LastService).AddMonths(x.ServiceInterval) < DateTime.Now.AddDays(7));

            return View("~/Views/Home/UpcomingServices.cshtml", customers);
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

        /// <summary>
        /// Returns the directions page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Directions(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var customer = CustomerRepository.GetCustomer(id);
                ViewBag.Customer = customer;
            }

            ViewBag.DefaultAddress = Settings.Default.DefaultAddress;

            return View("Directions");
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