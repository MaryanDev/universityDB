using PFMS.Entities.AbstractDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Entities.DTO
{
    public class EmpFullInfoDTO : BaseFullPersonInfoDTO
    {
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public IEnumerable<PrintingMachineDTO> Machines { get; set; }
    }
}
