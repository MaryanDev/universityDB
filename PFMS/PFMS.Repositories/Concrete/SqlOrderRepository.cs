using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;
using PFMS.Entities.DTO;

namespace PFMS.Repositories.Concrete
{
    public class SqlOrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public SqlOrderRepository(PintingFactoryDBEntities context) : base(context)
        {

        }

        public IEnumerable<OrderFullInfoDTO> GetFullOrdersInfo(/*Func<Order, bool> criteria = null*/ string name, string product)
        {
            IEnumerable<OrderFullInfoDTO> result;
            //if(criteria != null)
            //{
            //result = context.Orders.Include("Customer.Person").Include("Product").Where(criteria).Join(context.Customers, o => o.CustomerId, cust => cust.PersonId, (o, cust) => new { o, cust })
            //    .Join(context.Products, combined => combined.o.ProductId, prod => prod.Id, (combined, prod) => new OrderFullInfoDTO
            //    {
            //        Id = combined.o.Id,
            //        CustomersFirstName = combined.cust.Person.FirstName,
            //        CustomersLastName = combined.cust.Person.LastName,
            //        Product = prod.Title,
            //        Quantity = combined.o.Quantity,
            //        TotalPrice = (decimal)(combined.o.Quantity * prod.Cost)
            //    });

            result = from order in context.Orders
                     join cust in context.Customers on order.CustomerId equals cust.PersonId
                     join person in context.Persons on cust.PersonId equals person.ID
                     join prod in context.Products on order.ProductId equals prod.Id
                     where (person.FirstName.ToLower() + " " + person.LastName.ToLower()).Contains(name) && prod.Title.ToLower().Contains(product)
                     select new OrderFullInfoDTO
                     {
                         Id = order.Id,
                         CustomersFirstName = cust.Person.FirstName,
                         CustomersLastName = cust.Person.LastName,
                         Quantity = order.Quantity,
                         Product = prod.Title,
                         TotalPrice = (decimal)(order.Quantity * prod.Cost)
                     };
            //}
            //else
            //{
            //    result = context.Orders.Join(context.Customers, o => o.CustomerId, cust => cust.PersonId, (o, cust) => new { o, cust })
            //        .Join(context.Products, combined => combined.o.ProductId, prod => prod.Id, (combined, prod) => new OrderFullInfoDTO
            //        {
            //            Id = combined.o.Id,
            //            CustomersFirstName = combined.cust.Person.FirstName,
            //            CustomersLastName = combined.cust.Person.LastName,
            //            Product = prod.Title,
            //            Quantity = combined.o.Quantity,
            //            TotalPrice = (decimal)(combined.o.Quantity * prod.Cost)
            //        });
            //}

            return result.ToList();
        }
    }
}
