using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceDB
{
    public class Permission
    {
        public int pID{get; set;}
        public string pName { get; set; }
        public Permission() { }
        public Permission(int pID, string pName)
        {
            this.pID = pID;
            this.pName = pName;
           
        }
    }
}