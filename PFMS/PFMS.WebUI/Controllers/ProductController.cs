using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController()
        {
            this._unit = new Repositories.Concrete.UoW.UnitOfWork(new Entities.PintingFactoryDBEntities());
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var result = _unit.ProductRepo.Get().Select(p => new
            {
                Id = p.Id,
                Title = p.Title,
                Cost = p.Cost,
                Orders = _unit.OrderRepo.GetCountOfRecords(o => o.ProductId == p.Id)
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}