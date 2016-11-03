using PFMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult UpdateProduct(Product productToUpdate)
        {
            _unit.ProductRepo.Update(productToUpdate);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult CreateProduct(Product productToCreate)
        {
            _unit.ProductRepo.Insert(productToCreate);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}