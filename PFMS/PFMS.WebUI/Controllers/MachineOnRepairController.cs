using PFMS.Repositories.Concrete.UoW;
using PFMS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFMS.Entities;
using PFMS.Entities.DTO;
using System.Net;

namespace PFMS.WebUI.Controllers
{
    public class MachineOnRepairController : BaseController
    {
        public MachineOnRepairController()
        {
            _unit = new UnitOfWork(new Entities.PintingFactoryDBEntities());
        }

        [HttpPost]
        public JsonResult GetMachinesOnRepair(SearchMachineModel searchModel, int page = 1)
        {
            searchModel.Type = searchModel.Type.Trim();
            Func<MachinesForRepair, bool> criteria = m => m.PrintingMachine.Model.ToLower().Contains(searchModel.Model.ToLower()) && m.PrintingMachine.TypesOfMachine.TypeTitle.ToLower().Contains(searchModel.Type.ToLower());
            var machines = _unit.RepairRepo.Get(criteria).
                Skip((page - 1) * pageSize).Take(pageSize).Select(m => new
                {
                    Id = m.Id,
                    Model = m.PrintingMachine.Model,
                    RepairStartDate = m.RepairStartDate.ToString("MM/dd/yyyy"),
                    RepairFinishDate = m.RepairFinishDate != null ? ((DateTime)m.RepairFinishDate).ToString("MM/dd/yyyy") : null
                });
            int count = GetCountOfPages(_unit.RepairRepo.GetCountOfRecords(criteria), pageSize);

            return Json(new { machinesOnRepair = machines, allPages = count, currentPage = page });
        }

        [HttpGet]
        public JsonResult GetFullMachineOnRepairInfo(int machineId)
        {
            var machine = _unit.RepairRepo.Get(mr => mr.Id == machineId).Select(m => new MachineOnRepairFullInfoDTO
            {
                Id = m.Id,
                Model = m.PrintingMachine.Model,
                Type = m.PrintingMachine.TypesOfMachine.TypeTitle,
                RepairCost = m.CostOfRepair,
                RepairStartDate = m.RepairStartDate.ToString("MM/dd/yyyy"),
                RepairFinishDate = m.RepairFinishDate != null ? ((DateTime)m.RepairFinishDate).ToString("MM/dd/yyyy") : null
            }).SingleOrDefault();

            return Json(machine, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateMachineOnRepair(MachineOnRepairFullInfoDTO machineOnRepairToUpdate)
        {
            DateTime? finishDate;
            if (string.IsNullOrEmpty(machineOnRepairToUpdate.RepairFinishDate))
            {
                finishDate = null;
            }
            else
            {
                finishDate = Convert.ToDateTime(machineOnRepairToUpdate.RepairFinishDate);
            }
            var entityToUpdate = _unit.RepairRepo.GetSingle(mr => mr.Id == machineOnRepairToUpdate.Id);

            entityToUpdate.RepairStartDate = Convert.ToDateTime(machineOnRepairToUpdate.RepairStartDate);
            entityToUpdate.RepairFinishDate = finishDate;
            entityToUpdate.CostOfRepair = machineOnRepairToUpdate.RepairCost;

            _unit.RepairRepo.Update(entityToUpdate);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult EndRepair(int machineOnRepairId)
        {
            var entityToClose = _unit.RepairRepo.GetSingle(mr => mr.Id == machineOnRepairId);
            entityToClose.RepairFinishDate = (DateTime?)DateTime.Now;
            _unit.RepairRepo.Update(entityToClose);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}