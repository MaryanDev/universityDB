using PFMS.Entities;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        #region Provate fields
        private UnitOfWork _unit;
        private int pageSize = 15;
        #endregion

        #region Constructors
        public EmployeeController()
        {
            _unit = new UnitOfWork(new PintingFactoryDBEntities());
        }

        public EmployeeController(UnitOfWork unitParam)
        {
            this._unit = unitParam;
        }
        #endregion

        #region JsonActionMethods
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

        public JsonResult GetEmployeesPosition()
        {
            var positions = _unit.PositionRepo.Get();
            return Json(positions, JsonRequestBehavior.AllowGet);
        }

        public void UpdateEmployee()
        {

        }
        #endregion

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
