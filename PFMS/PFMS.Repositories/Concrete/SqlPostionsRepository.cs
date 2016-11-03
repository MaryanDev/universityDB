using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;

namespace PFMS.Repositories.Concrete
{
    public class SqlPositionsRepository : BaseRepository<EmpPosition>, IPositionRepository
    {
        public SqlPositionsRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
    }
}
