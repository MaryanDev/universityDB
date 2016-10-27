using PFMS.Entities;
using PFMS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        IEnumerable<EmpInfoDTO> GetEmpInfo(Func<Person, bool> criteria = null);
    }
}
