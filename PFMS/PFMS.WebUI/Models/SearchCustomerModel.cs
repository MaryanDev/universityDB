using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Models
{
    public class SearchCustomerModel : SearchPersonModel
    {
        public string Account { get; set; }
    }
}