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
        public ActionResult GetCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>();

            customers = CustomerRepository.GetCustomers();

            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}