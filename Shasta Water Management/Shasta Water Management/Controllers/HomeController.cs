using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shasta_Water_Management.Filters;
using Shasta_Water_Management.Repositories;

namespace Shasta_Water_Management.Controllers
{
    [LogInFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/");
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
            



            

            

            var custs = CustomerRepository.GetCustomers();

            return Json(custs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStates()
        {
            var states = StatesHelper.States.GetStatesFromXML().Where(x => x.Country.Equals("US"));

            return Json(states, JsonRequestBehavior.AllowGet);
        }
    }
}