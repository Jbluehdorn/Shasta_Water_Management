using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shasta_Water_Management.Models
{
    public class GlobalVariables
    {
        static GlobalVariables()
        {
            LoggedIn = "N";
        }

        public static string LoggedIn
        {
            get { return HttpContext.Current.Application["LoggedIn"] as string; }
            set { HttpContext.Current.Application["LoggedIn"] = value; }
        }
    }
}