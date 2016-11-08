using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Models
{
    public class SearchOrderModel
    {
        private string _customerName = "";
        private string _productTitle = "";

        public string CustomerName
        {
            get
            {
                return _customerName;
            }

            set
            {
                _customerName = value == null ? "" : value;
            }
        }

        public string ProductTitle
        {
            get
            {
                return _productTitle;
            }

            set
            {
                _productTitle = value == null ? "" : value;
            }
        }
    }
}