using PFMS.Entities;
using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Concrete
{
    public class SqlProductsToMachinesRepository : BaseRepository<ProductsToMachine>
    {
        public SqlProductsToMachinesRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
    }
}
