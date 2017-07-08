using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class GlobalClass
    {
        static private string _SystemSession = "SystemSession";
        public static bool SystemSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._SystemSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._SystemSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._SystemSession] = value;
            }
        }
        static private string _AnchorID = "AnchorID";
        public static int AnchorID
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._AnchorID] == null)
                {
                    return -99;
                }
                else
                {
                    return (int)(HttpContext.Current.Session[GlobalClass._AnchorID]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._AnchorID] = value;
            }
        }
        static private string _UserDetail = "UserDetail";
        public static CustomerLogin UserDetail
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._UserDetail] == null)
                {
                    return null;
                }
                else
                {
                    return (CustomerLogin)(HttpContext.Current.Session[GlobalClass._UserDetail]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._UserDetail] = value;
            }
        }
        static private string _LoginUser = "LoginUser";
        public static CustomerContact LoginUser
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LoginUser] == null)
                {
                    return null;
                }
                else
                {
                    return (CustomerContact)(HttpContext.Current.Session[GlobalClass._LoginUser]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LoginUser] = value;
            }
        }
        static private string _Company = "Company";
        public static Company Company
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._Company] == null)
                {
                    return null;
                }
                else
                {
                    return (Company)(HttpContext.Current.Session[GlobalClass._Company]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._Company] = value;
            }
        }
        static private string _CustomerDetail = "CustomerDetail";
        public static Customer CustomerDetail
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._CustomerDetail] == null)
                {
                    return null;
                }
                else
                {
                    return (Customer)(HttpContext.Current.Session[GlobalClass._CustomerDetail]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._CustomerDetail] = value;
            }
        }
    }
}