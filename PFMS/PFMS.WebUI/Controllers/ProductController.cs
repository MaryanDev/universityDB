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
            _unit.Save();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult CreateProduct(Product productToCreate)
        {
            _unit.ProductRepo.Insert(productToCreate);
            _unit.Save();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product productToDelete)
        {
            var ordersToDelete = _unit.OrderRepo.Get(o => o.ProductId == productToDelete.Id);
            if(ordersToDelete.Count() != 0)
            {
                foreach(var order in ordersToDelete)
                {
                    _unit.OrderRepo.Delete(order);
                    _unit.Save();
                }
            }
            var itemsToDelete = _unit.ProdMachineRepo.Get(pmt => pmt.ProductId == productToDelete.Id);
            if(itemsToDelete.Count() != 0)
            {
                foreach(var item in itemsToDelete)
                {
                    _unit.ProdMachineRepo.Delete(item);
                    _unit.Save();
                }
            }
            
            _unit.ProductRepo.Delete(productToDelete);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}