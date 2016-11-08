using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMS.WebUI.Models
{
    public class SearchPersonModel
    {
        private string _firstName = "";
        private string _lastName = "";
        private string _address = "";
        private string _phone = "";

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value == null ?  "" : value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value == null ? "" : value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value == null ? "" : value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value == null ? "" : value;
            }
        }

        public bool IsModelEmpty()
        {
            bool empty = true;
            if(!string.IsNullOrEmpty(_firstName) 
                || !string.IsNullOrEmpty(_lastName) 
                || !string.IsNullOrEmpty(_address)
                || !string.IsNullOrEmpty(_phone))
            {
                empty = false;
            }

            return empty;
        }
    }
}