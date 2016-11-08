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

        public IEnumerable<OrderFullInfoDTO> GetFullOrdersInfo(Func<Order, bool> criteria = null)
        {
            IEnumerable<OrderFullInfoDTO> result;
            if(criteria != null)
            {
                result = context.Orders.Where(criteria).Join(context.Customers, o => o.CustomerId, cust => cust.PersonId, (o, cust) => new { o, cust })
                    .Join(context.Products, combined => combined.o.ProductId, prod => prod.Id, (combined, prod) => new OrderFullInfoDTO
                    {
                        Id = combined.o.Id,
                        CustomersFirstName = combined.cust.Person.FirstName,
                        CustomersLastName = combined.cust.Person.LastName,
                        Product = prod.Title,
                        Quantity = combined.o.Quantity,
                        TotalPrice = (decimal)(combined.o.Quantity * prod.Cost)
                    });
            }
            else
            {
                result = result = context.Orders.Join(context.Customers, o => o.CustomerId, cust => cust.PersonId, (o, cust) => new { o, cust })
                    .Join(context.Products, combined => combined.o.ProductId, prod => prod.Id, (combined, prod) => new OrderFullInfoDTO
                    {
                        Id = combined.o.Id,
                        CustomersFirstName = combined.cust.Person.FirstName,
                        CustomersLastName = combined.cust.Person.LastName,
                        Product = prod.Title,
                        Quantity = combined.o.Quantity,
                        TotalPrice = (decimal)(combined.o.Quantity * prod.Cost)
                    });
            }

            return result;
        }
    }
}
