using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceDB
{
    public class UP
    {
         public int uID{get; set;}
        public int pID { get; set; }
        public int pTimes { get; set; }
        public string details { get; set; }
        public UP() { }
        public UP(int uID, int pID,int pTimes,string details)
        {
            this.uID = uID;
            this.pID = pID;
            this.pTimes = pTimes;
            this.details = details;

           
        }
    }
}