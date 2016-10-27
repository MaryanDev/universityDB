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
        private int pageSize = 15;

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
            //_unit.PersonRepo.Delete(_unit.PersonRepo.GetSingle(p => p.FirstName == "Maryan"));
            //_unit.Save();
            return View();
        }

        public JsonResult GetEmployeesInfo(int page = 1)
        {
            var result = _unit.EmployeeRepo.GetSimpleEmpInfo().Skip((page - 1) * pageSize).Take(pageSize);
            var count = GetCountOfPages(_unit.EmployeeRepo.GetCountOfRecords(), pageSize);
            return Json(new { allPages = count, employees = result, currentPage = page }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFullEmployeeInfo(int employeeId)
        {
            var employeeEntity = _unit.EmployeeRepo.GetFullEmpInfo(emp => emp.PersonId == employeeId);
            return Json(employeeEntity, JsonRequestBehavior.AllowGet);
        }

        #region Helpers
        private int GetCountOfPages(int allPages, int size)
        {
            var pages = allPages / size;
            var count = allPages % size == 0 ? pages : ++pages;
            return count;
        }
        #endregion
    }
}