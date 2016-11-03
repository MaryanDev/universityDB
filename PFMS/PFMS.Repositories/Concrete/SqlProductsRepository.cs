using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;

namespace PFMS.Repositories.Concrete
{
    public class SqlProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public SqlProductsRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
    }
}
