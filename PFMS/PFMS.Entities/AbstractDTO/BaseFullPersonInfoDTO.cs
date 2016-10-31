using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Entities.AbstractDTO
{
    public abstract class BaseFullPersonInfoDTO : BasePersonInfoDTO
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
    }
}
