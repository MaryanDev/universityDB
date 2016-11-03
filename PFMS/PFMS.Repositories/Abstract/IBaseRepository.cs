using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface IBaseRepository
    {
        void Delete<TEntity>(Func<TEntity, bool> criteria) where TEntity : class;
        IEnumerable<TEntity> Get<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class;
        TEntity GetSingle<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class;
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
