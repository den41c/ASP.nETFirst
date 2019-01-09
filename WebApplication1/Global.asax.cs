using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
	using System.Data.Entity;

	using WebApplication1.Models;

	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			//Database.SetInitializer(new BookDbInit());
			//var boks = new BookContext();
			//var t = boks.Books.Select(w => w.Id);
			
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
