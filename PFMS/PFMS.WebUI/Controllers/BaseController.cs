using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork _unit;
        protected int pageSize = 15;
    }
}