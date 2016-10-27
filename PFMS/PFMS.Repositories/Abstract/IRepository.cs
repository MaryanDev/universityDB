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
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
