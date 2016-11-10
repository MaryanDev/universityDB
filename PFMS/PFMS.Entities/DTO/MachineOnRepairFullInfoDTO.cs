using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Entities.DTO
{
    public class MachineOnRepairFullInfoDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string RepairStartDate { get; set; }
        public string RepairFinishDate { get; set; }
        public decimal RepairCost { get; set; }
    }
}
