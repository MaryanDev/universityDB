using PFMS.Entities;
using PFMS.WebUI.Models;
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

        [HttpPost]
        public JsonResult GetProducts(SearchProductModel searchModel, int page = 1)
        {
            Func<Product, bool> criteria = prod => prod.Title.ToLower().Contains(searchModel.Title.ToLower()) &&
                            (int)prod.Cost >= searchModel.MinCost && prod.Cost <= searchModel.MaxCost;
            var result = _unit.ProductRepo.Get(criteria).Skip((page - 1) * pageSize).Take(pageSize).Select(p => new
            {
                Id = p.Id,
                Title = p.Title,
                Cost = p.Cost,
                Orders = _unit.OrderRepo.GetCountOfRecords(o => o.ProductId == p.Id)
            });

            int count = GetCountOfPages(_unit.ProductRepo.GetCountOfRecords(criteria), pageSize);
            return Json(new { products = result, allPages = count, currentPage = page }, JsonRequestBehavior.AllowGet);
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
            _unit.ProductRepo.Delete(productToDelete);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public JsonResult GetProductsByTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var matchingProducts = _unit.ProductRepo.Get(prod => prod.Title.ToLower().Contains(title.ToLower()))
                    .Select(p => new
                    {
                        Id = p.Id,
                        Cost = p.Cost,
                        Title = p.Title
                    });
                return Json(matchingProducts, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }

        }
    }
}