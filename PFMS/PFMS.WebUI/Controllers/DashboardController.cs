using PFMS.Entities;
using PFMS.Repositories.Abstract;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFMS.Entities.DTO;

namespace PFMS.WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private UnitOfWork _unit;

        public DashboardController()
        {
            _unit = new UnitOfWork(new PintingFactoryDBEntities());
        }

        public DashboardController(UnitOfWork unitParam)
        {
            this._unit = unitParam;
        }
        // GET: Dashboard
        public ActionResult Main()
        {
            //_unit.PersonRepo.Delete(_unit.PersonRepo.GetSingle(p => p.FirstName == "Maryan"));
            //_unit.Save();
            return View();
        }
    }
}