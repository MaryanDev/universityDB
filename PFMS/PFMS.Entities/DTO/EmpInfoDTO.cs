﻿using PFMS.Entities.AbstractDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Entities.DTO
{
    public class EmpInfoDTO : BasePersonInfoDTO
    {
        public string Position { get; set; }
    }
}
