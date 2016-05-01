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
            var customer = new Customer();
            var equip = new CustEquip();

            

            customer.CustomerID = 30;

            customer.Name = "Barb Cena";

            customer.Address = "3484 urhgieurhge";

            customer.CellPhoneNum = "6666666666";

            customer.Notes = "CATS ARE CATS ARE CATS";

            equip.CustomerID = customer.CustomerID;

            equip.ModelNum = "gerugheriug";

            equip.Diagnostics = "diagnorteirhjg";



            

            CustomerRepository.AddCustomer(customer);

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