using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Entities.DTO
{
    public class EmpFullInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public IEnumerable<PrintingMachineDTO> Machines { get; set; }
    }
}
