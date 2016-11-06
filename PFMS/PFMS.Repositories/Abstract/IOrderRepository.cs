using PFMS.Entities;
using PFMS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<OrderFullInfoDTO> GetFullOrdersInfo(Func<Order, bool> criteria = null);
    }
}
