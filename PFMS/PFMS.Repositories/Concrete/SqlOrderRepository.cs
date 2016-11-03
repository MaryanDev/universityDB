using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;

namespace PFMS.Repositories.Concrete
{
    public class SqlOrderRepository : BaseRepository, IOrderRepository
    {
        public SqlOrderRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get(Func<Order, bool> criteria = null)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfRecords(Func<Order, bool> criteria = null)
        {
            return criteria == null ? context.Orders.Count() : context.Orders.Where(criteria).Count();
        }

        public Order GetSingle(Func<Order, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public Order Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
