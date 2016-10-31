using PFMS.Entities;
using PFMS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        IEnumerable<CustomerInfoDTO> GetSimpleCustomerInfo(Func<Customer, bool> criteria = null);
    }
}
