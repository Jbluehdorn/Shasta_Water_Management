using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shasta_Water_Management.Repositories;

namespace Shasta_Water_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Test()
        {
            var customers = CustomerRepository.GetCustomers();

            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}