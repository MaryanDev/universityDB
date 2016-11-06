using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Entities.DTO
{
    public class OrderFullInfoDTO
    {
        public int Id { get; set; }
        public string CustomersFirstName { get; set; }
        public string CustomersLastName { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
