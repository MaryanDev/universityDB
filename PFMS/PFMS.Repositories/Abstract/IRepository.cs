using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get(Func<TEntity, bool> criteria = null);
        TEntity GetSingle(Func<TEntity, bool> criteria);
        void Delete(TEntity entity);
        int Insert(TEntity entity);
        int GetCountOfRecords(Func<TEntity, bool> criteria = null);
        TEntity Update(TEntity entity);
    }
}
