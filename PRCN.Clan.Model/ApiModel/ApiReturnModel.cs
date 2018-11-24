using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Model.ApiModel
{
    public class ApiReturnModel
    {
        public bool result { get; set; }

        public string message { get; set; }

        public object data { get; set; }
    }
}