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
    public class OrderController : BaseController
    {
        public OrderController()
        {
            _unit = new UnitOfWork(new PintingFactoryDBEntities());
        }

        [HttpGet]
        public JsonResult GetOrders(int page = 1)
        {
            var orders = _unit.OrderRepo.GetFullOrdersInfo().Skip((page - 1) * pageSize).Take(pageSize);
            var count = GetCountOfPages(_unit.OrderRepo.GetCountOfRecords(), pageSize);
            return Json(new { allPages = count, orders = orders, currentPage = page }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderFullInfoDTO orderToCreate)
        {
            try
            {
                var customerId = _unit.CustomerRepo.GetSingle(cust => cust.Person.FirstName == orderToCreate.CustomersFirstName
                    && cust.Person.LastName == orderToCreate.CustomersLastName).PersonId;
                var productId = _unit.ProductRepo.GetSingle(prod => prod.Title == orderToCreate.Product).Id;

                _unit.OrderRepo.Insert(new Order
                {
                    CustomerId = customerId,
                    ProductId = productId,
                    Quantity = orderToCreate.Quantity
                });
                _unit.Save();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                //return Json("The customer or product was not found, please select right info", JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The customer or product was not found, please select right info");
            }
        }

        [HttpPost]
        public ActionResult UpdateOrder(OrderFullInfoDTO orderToUpdate)
        {

            var customerId = _unit.CustomerRepo.GetSingle(cust => cust.Person.FirstName == orderToUpdate.CustomersFirstName
                && cust.Person.LastName == orderToUpdate.CustomersLastName).PersonId;
            var productId = _unit.ProductRepo.GetSingle(prod => prod.Title == orderToUpdate.Product).Id;

            var order = _unit.OrderRepo.GetSingle(o => o.Id == orderToUpdate.Id);
            order.CustomerId = customerId;
            order.ProductId = productId;
            order.Quantity = orderToUpdate.Quantity;

            _unit.OrderRepo.Update(order);
            _unit.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);

            //return Json("The customer or product was not found, please select right info", JsonRequestBehavior.AllowGet);
            return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The customer or product was not found, please select right info");

        }

        [HttpPost]
        public ActionResult DeleteOrder(OrderFullInfoDTO orderToDelete)
        {
            _unit.OrderRepo.Delete(_unit.OrderRepo.GetSingle(o => o.Id == orderToDelete.Id));
            _unit.Save();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}