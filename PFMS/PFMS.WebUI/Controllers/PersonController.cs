using PFMS.Entities;
using PFMS.Entities.DTO;
using PFMS.Repositories.Concrete.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    [Authorize]
    public class PersonController : BaseController
    {
        #region Provate fields
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

        #region Json Employee Methods
        public JsonResult GetEmployeesInfo(int page = 1, int? personId = null)
        {
            IEnumerable<EmpInfoDTO> result;
            int count;
            if(personId == null)
            {
                result = _unit.EmployeeRepo.GetSimpleEmpInfo().Skip((page - 1) * pageSize).Take(pageSize);
                count = GetCountOfPages(_unit.EmployeeRepo.GetCountOfRecords(), pageSize);
            }
            else
            {
                result = _unit.EmployeeRepo.GetSimpleEmpInfo(emp => emp.PersonId == personId);
                count = 0;
            }
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

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            var empToDelete = _unit.EmployeeRepo.GetSingle(emp => emp.PersonId == id);
            _unit.EmployeeRepo.Delete(emp => emp.PersonId == id);
            _unit.Save();

            var personToDelete = _unit.PersonRepo.GetSingle(person => person.ID == id);
            _unit.PersonRepo.Delete(per => per.ID == id);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        #endregion

        #region Json Customers Methods
        public JsonResult GetCustomersInfo(int page = 1, int? personId = null)
        {
            IEnumerable<CustomerInfoDTO> result;
            int count;
            if (personId == null)
            {
                result = _unit.CustomerRepo.GetSimpleCustomerInfo().Skip((page - 1) * pageSize).Take(pageSize);
                count = GetCountOfPages(_unit.CustomerRepo.GetCountOfRecords(), pageSize);
            }
            else
            {
                result = _unit.CustomerRepo.GetSimpleCustomerInfo(cus => cus.PersonId == personId);
                count = 0;
            }
            return Json(new { allPages = count, customers = result, currentPage = page }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFullCustomerInfo(int customerId)
        {
            var customerEntity = _unit.CustomerRepo.GetFullCustomerInfo(cus => cus.PersonId == customerId);
            return Json(customerEntity, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerFullInfoDTO customerToCreate)
        {
            var createdPerson = _unit.PersonRepo.Insert(new Person
            {
                FirstName = customerToCreate.FirstName,
                LastName = customerToCreate.LastName,
                PhoneNumber = customerToCreate.Phone,
                DateOfBirth = Convert.ToDateTime(customerToCreate.DateOfBirth),
                Address = customerToCreate.Address
            });
            _unit.Save();
            _unit.CustomerRepo.Insert(new Customer
            {
                PersonId = createdPerson.ID,
                AccountNumber = customerToCreate.AccountNumber
            });
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerFullInfoDTO customerToUpdate)
        {
            _unit.PersonRepo.Update(new Person
            {
                ID = customerToUpdate.Id,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName,
                Address = customerToUpdate.Address,
                DateOfBirth = Convert.ToDateTime(customerToUpdate.DateOfBirth),
                PhoneNumber = customerToUpdate.Phone
            });
            _unit.Save();
            _unit.CustomerRepo.Update(new Customer
            {
                PersonId = customerToUpdate.Id,
                AccountNumber = customerToUpdate.AccountNumber
            });
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            var customerToDelete = _unit.CustomerRepo.GetSingle(cus => cus.PersonId == id);
            _unit.CustomerRepo.Delete(cust => cust.PersonId == id);
            _unit.Save();

            var personToDelete = _unit.PersonRepo.GetSingle(person => person.ID == id);
            _unit.PersonRepo.Delete(per => per.ID == id);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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
