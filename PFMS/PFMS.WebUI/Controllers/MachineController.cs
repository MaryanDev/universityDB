using PFMS.Entities;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    public class MachineController : BaseController
    {
        public MachineController()
        {
            _unit = new UnitOfWork(new PintingFactoryDBEntities());
        }
    }
}