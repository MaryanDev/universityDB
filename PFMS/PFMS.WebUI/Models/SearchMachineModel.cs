using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Models
{
    public class SearchMachineModel
    {
        private string _model = "";
        private string _type = "";

        public string Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value == null ? "" : value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value == null ? "" : value;
            }
        }
    }
}