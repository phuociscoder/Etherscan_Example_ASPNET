
using Etherscan.Repository;
using Etherscan.Repository.Interfaces;
using Etherscan.Service;
using Etherscan.Service.Interfaces;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Unity;
using Unity.Injection;

namespace EtherscanExample
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);
            var container = this.AddUnity();
            container.RegisterType<ITokenServices, TokenServices>();
            container.RegisterType<ITokenRepository, TokenRepository>(new InjectionConstructor(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString));
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "CoinListRoute",
                "Coin",
                "~/Coin.aspx"
            );
        }
    }
}