using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;

namespace PFMS.Repositories.Concrete
{
    public class SqlPostionsRepository : BaseRepository, IPositionRepository
    {
        public SqlPostionsRepository(PintingFactoryDBEntities context) : base(context)
        {

        }

        public void Delete(EmpPosition entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<EmpPosition> Get(Func<EmpPosition, bool> criteria = null)
        {
            var result = criteria == null ? context.EmpPositions : context.EmpPositions.Where(criteria);
            return result;
        }

        public int GetCountOfRecords(Func<EmpPosition, bool> criteria = null)
        {
            return criteria == null ? context.EmpPositions.Count() : context.EmpPositions.Where(criteria).Count();
        }

        public EmpPosition GetSingle(Func<EmpPosition, bool> criteria)
        {
            var resultEntity = criteria == null ? context.EmpPositions.FirstOrDefault() : context.EmpPositions.Where(criteria).FirstOrDefault();
            return resultEntity;
        }

        public int Insert(EmpPosition entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return entity.Id;
        }

        public EmpPosition Update(EmpPosition entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }
    }
}
