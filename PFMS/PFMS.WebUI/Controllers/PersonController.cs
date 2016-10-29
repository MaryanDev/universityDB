using PFMS.Entities;
using PFMS.Entities.DTO;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        #region Provate fields
        private UnitOfWork _unit;
        private int pageSize = 15;
        #endregion

        #region Constructors
        public PersonController()
        {
            _unit = new UnitOfWork(new PintingFactoryDBEntities());
        }

        public PersonController(UnitOfWork unitParam)
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
            var result = positions.Select(p => new
            {
                Id = p.Id,
                PositionTitle = p.PositionTitle
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(EmpFullInfoDTO empToUpdate)
        {
            _unit.PersonRepo.Update(new Person
            {
                ID = empToUpdate.Id,
                FirstName = empToUpdate.FirstName,
                LastName = empToUpdate.LastName,
                Address = empToUpdate.Address,
                DateOfBirth = Convert.ToDateTime(empToUpdate.DateOfBirth),
                PhoneNumber = empToUpdate.Phone
            });
            _unit.Save();
            _unit.EmployeeRepo.Update(new Employee
            {
                PersonId = empToUpdate.Id,
                PositionId = _unit.PositionRepo.GetSingle(pos => pos.PositionTitle == empToUpdate.Position).Id
            });
            _unit.Save();

            return Redirect("/Dashboard/Main");
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmpFullInfoDTO employeeToCreate)
        {
            var createdPerson = _unit.PersonRepo.Insert(new Person
            {
                FirstName = employeeToCreate.FirstName,
                LastName = employeeToCreate.LastName,
                PhoneNumber = employeeToCreate.Phone,
                DateOfBirth = Convert.ToDateTime(employeeToCreate.DateOfBirth),
                Address = employeeToCreate.Address
            });
            _unit.Save();
            _unit.EmployeeRepo.Insert(new Employee
            {
                PersonId = createdPerson.ID,
                PositionId = _unit.PositionRepo.GetSingle(pos => pos.PositionTitle == employeeToCreate.Position).Id
            });
            _unit.Save();

            return Redirect("/Dashboard/Main");
        }

        [HttpPost]
        public void DeleteEmployee(int id)
        {
            var empToDelete = _unit.EmployeeRepo.GetSingle(emp => emp.PersonId == id);
            _unit.EmployeeRepo.Delete(empToDelete);
            _unit.Save();

            var personToDelete = _unit.PersonRepo.GetSingle(person => person.ID == id);
            _unit.PersonRepo.Delete(personToDelete);
            _unit.Save();
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
