using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;

namespace PFMS.Repositories.Concrete
{
    class SqlPersonRepository : BaseRepository, IPersonRepository
    {
        public SqlPersonRepository(PintingFactoryDBEntities context) : base(context)
        {

        }

        //public SqlPrintingMachineRepository(string connectionString): base(connectionString)
        //{

        //}
        public void Delete(Person entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<Person> Get(Func<Person, bool> criteria = null)
        {
            var resultEntities = criteria == null ? context.Persons : context.Persons.Where(criteria);
            return resultEntities;
        }

        public Person GetSingle(Func<Person, bool> criteria = null)
        {
            var resultEntity = criteria == null ? context.Persons.FirstOrDefault() : context.Persons.Where(criteria).FirstOrDefault();
            return resultEntity;
        }

        public Person Insert(Person entity)
        {
            context.Set<Person>().Add(entity);
            return entity;
        }

        public Person Update(Person entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public int GetCountOfRecords(Func<Person, bool> criteria = null)
        {
            return criteria == null ? context.Persons.Count() : context.Persons.Where(criteria).Count();
        }
    }
}
