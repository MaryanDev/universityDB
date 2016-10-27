using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Infrastructure.Authentification
{
    public class PrintingFactoryUserManager : UserManager<PrintingFactoryUser>
    {
        public PrintingFactoryUserManager(IUserStore<PrintingFactoryUser> store) : base(store)
        {

        }

        public static PrintingFactoryUserManager  Create(IdentityFactoryOptions<PrintingFactoryUserManager> options, IOwinContext context)
        {
            PrintingFactoryIdentityDbContext db = context.Get<PrintingFactoryIdentityDbContext>();
            PrintingFactoryUserManager manager = new PrintingFactoryUserManager(new UserStore<PrintingFactoryUser>(db));
            return manager;
        }
    }
}