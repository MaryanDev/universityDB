using PFMS.Entities;
using PFMS.Entities.DTO;
using PFMS.Repositories.Concrete.UoW;
using PFMS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public JsonResult GetSimpleMachineInfo(SearchMachineModel searchModel, int page = 1)
        {
            searchModel.Type = searchModel.Type.Trim();
            Func<PrintingMachine, bool> criteria = m => m.Model.ToLower().Contains(searchModel.Model.ToLower()) && m.TypesOfMachine.TypeTitle.ToLower().Contains(searchModel.Type.ToLower());
            var machines = _unit.MachineRepo.Get(criteria).
                Skip((page - 1) * pageSize).Take(pageSize).Select(m => new
                {
                    Id = m.Id,
                    Model = m.Model,
                    Type = m.TypesOfMachine.TypeTitle,
                    OnRepair = _unit.RepairRepo.GetSingle(mr => mr.MachineId == m.Id) == null ? false : true
                });
            int count = GetCountOfPages(_unit.MachineRepo.GetCountOfRecords(criteria), pageSize);

            return Json(new { machines = machines, allPages = count, currentPage = page });
        }

        [HttpGet]
        public JsonResult GetMachinesTypes()
        {
            var types = _unit.MachineTypeRepo.Get().Select(mt => new
            {
                Id = mt.Id,
                TypeTitle = mt.TypeTitle
            });

            return Json(types, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFullMachineInfo(int machineId)
        {
            var info = _unit.MachineRepo.Get(m => m.Id == machineId).Select(m => new PrintingMachineDTO
            {
                Id = m.Id,
                Model = m.Model,
                MachineType = m.TypesOfMachine.TypeTitle,
                EmployeeInCharge = m.Employee.Person.FirstName + " " + m.Employee.Person.LastName,
                Price = m.Price,
                OnRepair = _unit.RepairRepo.GetSingle(mr => mr.MachineId == m.Id) == null ? false : true
            }).SingleOrDefault();

            return Json(info, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateMachine(PrintingMachineDTO machineToCreate)
        {
            try
            {
                var employeeId = _unit.EmployeeRepo.GetSingle(emp => (emp.Person.FirstName + " " + emp.Person.LastName) == machineToCreate.EmployeeInCharge).PersonId;
                var typeId = _unit.MachineTypeRepo.GetSingle(mt => mt.TypeTitle == machineToCreate.MachineType).Id;

                _unit.MachineRepo.Insert(new PrintingMachine
                {
                    Id = machineToCreate.Id,
                    Model = machineToCreate.Model,
                    EmployeeInChargeId = employeeId,
                    Price = machineToCreate.Price,
                    MachineTypeId = typeId
                });
                _unit.Save();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                //return Json("The customer or product was not found, please select right info", JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The employee or type was not found, please select right info");
            }
        }

        [HttpPost]
        public ActionResult UpdateMachine(PrintingMachineDTO machineToUpdate)
        {
            try
            {
                var employeeId = _unit.EmployeeRepo.GetSingle(emp => (emp.Person.FirstName + " " + emp.Person.LastName) == machineToUpdate.EmployeeInCharge).PersonId;
                var typeId = _unit.MachineTypeRepo.GetSingle(mt => mt.TypeTitle == machineToUpdate.MachineType).Id;

                _unit.MachineRepo.Update(new PrintingMachine
                {
                    Id = machineToUpdate.Id,
                    Model = machineToUpdate.Model,
                    EmployeeInChargeId = employeeId,
                    Price = machineToUpdate.Price,
                    MachineTypeId = typeId
                });
                _unit.Save();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                //return Json("The customer or product was not found, please select right info", JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The employee or type was not found, please select right info");
            }
        }

        [HttpPost]
        public ActionResult DeleteMachine(int machineId)
        {
            _unit.MachineRepo.Delete(_unit.MachineRepo.GetSingle(m => m.Id == machineId));
            _unit.Save();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}