using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shasta_Water_Management.Controllers
{
    public class TemplateController : Controller
    {
        public PartialViewResult SearchTemplate()
        {
            return this.PartialView();
        }
    }
}