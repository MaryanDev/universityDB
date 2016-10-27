using PFMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
        int GetCountOfRecords(Func<Person, bool> criteria = null);
    }
}
