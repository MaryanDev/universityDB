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
        public ActionResult DeleteMachine(int machineId)
        {
            _unit.MachineRepo.Delete(_unit.MachineRepo.GetSingle(m => m.Id == machineId));
            _unit.Save();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}