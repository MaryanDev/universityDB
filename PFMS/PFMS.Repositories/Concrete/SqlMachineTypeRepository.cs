using PFMS.Entities;
using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Concrete
{
    public class SqlMachineTypeRepository : BaseRepository<TypesOfMachine>, IMachineTypeRepository
    {
        public SqlMachineTypeRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
    }
}
