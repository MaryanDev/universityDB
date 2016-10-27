using PFMS.Entities;
using PFMS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        EmpFullInfoDTO GetFullEmpInfo(Func<Employee, bool> criteria);
        IEnumerable<EmpInfoDTO> GetSimpleEmpInfo(Func<Employee, bool> criteria = null);
    }
}
