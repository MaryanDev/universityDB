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
        public JsonResult GetSimpleMachineInfo(SearchMachineModel searchModel)
        {
            searchModel.Type = searchModel.Type.Trim();
            var machines = _unit.MachineRepo.Get(m => m.Model.ToLower().Contains(searchModel.Model.ToLower()) && m.TypesOfMachine.TypeTitle.ToLower().Contains(searchModel.Type.ToLower())).Select(m => new
            {
                Id = m.Id,
                Model = m.Model,
                Type = m.TypesOfMachine.TypeTitle
            });

            return Json(machines);
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
                Price = m.Price
            }).SingleOrDefault();

            return Json(info, JsonRequestBehavior.AllowGet);
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