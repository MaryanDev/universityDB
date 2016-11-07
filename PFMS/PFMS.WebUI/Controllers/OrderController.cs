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
    }
}