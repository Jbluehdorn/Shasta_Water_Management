using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Shasta_Water_Management.Controllers;
using Shasta_Water_Management.Models;

namespace Shasta_Water_Management.Filters
{
    public class LogInFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof (SkipLoginFilter), false).Any())
            {
                return;
            }

            if(string.IsNullOrEmpty(GlobalVariables.LoggedIn))
                filterContext.Result = (new LoginController()).LoginPage();

            if (!GlobalVariables.LoggedIn.Equals("Y"))
                filterContext.Result = (new LoginController()).LoginPage();
        }
    }
}