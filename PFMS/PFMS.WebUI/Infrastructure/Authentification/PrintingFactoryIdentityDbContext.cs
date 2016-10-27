using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Infrastructure.Authentification
{
    public class PrintingFactoryIdentityDbContext : IdentityDbContext<PrintingFactoryUser>
    {
        public PrintingFactoryIdentityDbContext() : base("name=IdentityDb")
        {

        }

        public static PrintingFactoryIdentityDbContext Create()
        {
            return new Authentification.PrintingFactoryIdentityDbContext();
        }
    }
}