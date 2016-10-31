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
    public class SqlCustomersRepository : BaseRepository, ICustomersRepository
    {
        public SqlCustomersRepository(PintingFactoryDBEntities context) : base(context)
        {

        }

        public IEnumerable<CustomerInfoDTO> GetSimpleCustomerInfo(Func<Customer, bool> criteria = null)
        {
            var resultEntities = criteria != null ? context.Customers.Where(criteria).Join(context.Persons, cus => cus.PersonId, per => per.ID, (cus, per) => new CustomerInfoDTO
            {
                Id = cus.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                AccountNumber = cus.AccountNumber
            }) :
            context.Customers.Join(context.Persons, cus => cus.PersonId, per => per.ID, (cus, per) => new CustomerInfoDTO
            {
                Id = cus.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                AccountNumber = cus.AccountNumber
            });
            return resultEntities;
        }

        public void Delete(Customer entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> criteria = null)
        {
            var result = criteria == null ? context.Customers : context.Customers.Where(criteria);
            return result;
        }

        public int GetCountOfRecords(Func<Customer, bool> criteria = null)
        {
            return criteria == null ? context.Customers.Count() : context.Customers.Where(criteria).Count();
        }

        public Customer GetSingle(Func<Customer, bool> criteria)
        {
            var resultEntity = criteria == null ? context.Customers.FirstOrDefault() : context.Customers.Where(criteria).FirstOrDefault();
            return resultEntity;
        }

        public Customer Insert(Customer entity)
        {
            context.Set<Customer>().Add(entity);
            return entity;
        }

        public Customer Update(Customer entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }
    }
}
