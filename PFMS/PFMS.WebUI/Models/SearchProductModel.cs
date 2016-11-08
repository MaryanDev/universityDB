using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Models
{
    public class SearchProductModel
    {
        private string _title = "";
        private int? _minCost = 0;
        private int? _maxCost = int.MaxValue;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value == null ? "" : value;
            }
        }

        public int? MinCost
        {
            get
            {
                return _minCost;
            }

            set
            {
                _minCost = value == null ? 0 : value;
            }
        }

        public int? MaxCost
        {
            get
            {
                return _maxCost;
            }

            set
            {
                _maxCost = value == null ? int.MaxValue : value;
            }
        }
    }
}