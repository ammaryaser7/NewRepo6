using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using mvc_najehacademy.Models;
using System.Xml.Serialization;

namespace mvc_najehacademy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["useronline"] = int.Parse(Application["useronline"].ToString()) + 1;
            // GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
            //.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // GlobalConfiguration.Configuration.Formatters
            //   .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            // var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            //xml.UseXmlSerializer = true;

            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            // Use XmlSerializer for instances of type "Product":
            xml.SetSerializer<Major>(new XmlSerializer(typeof(Major)));

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_End()
        {
                        Application["useronline"] = int.Parse(Application["useronline"].ToString()) - 1;

        }
}
}
