using Book_aspC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Book_aspC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //User�e�[�u���쐬�p 
            //Database.SetInitializer<UserDBContext>(new Initialize_User_table());
            //Library�e�[�u���쐬�p
            //Database.SetInitializer<LibraryDBContext>(new Initialize_Library_table());
        }
    }
}
