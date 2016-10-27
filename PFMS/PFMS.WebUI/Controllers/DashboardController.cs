using PFMS.Entities;
using PFMS.Repositories.Abstract;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private UnitOfWork _unit;
        private int pageSize = 10;

        public DashboardController()
        {
            _unit = new UnitOfWork(new PintingFactoryDBEntities());
        }

        public DashboardController(UnitOfWork unitParam)
        {
            this._unit = unitParam;
        }
        // GET: Dashboard
        public ActionResult Index()
        { 
            return View();
        }

        public JsonResult GetPersons(int page = 1)
        {
            var result = _unit.PersonRepo.Get().Skip((page - 1) * pageSize).Take(pageSize);
            var allPages = _unit.PersonRepo.GetCountOfRecords() / pageSize;

            return Json(new { allPages = allPages, persons = result, currentPage = page }, JsonRequestBehavior.AllowGet);
        }
    }
}