using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PFMS.WebUI.Infrastructure.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.CreatePerOwinContext<PrintingFactoryIdentityDbContext>(PrintingFactoryIdentityDbContext.Create);
            builder.CreatePerOwinContext<PrintingFactoryUserManager>(PrintingFactoryUserManager.Create);

            builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}