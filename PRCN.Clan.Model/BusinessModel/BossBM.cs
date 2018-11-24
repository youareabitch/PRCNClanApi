using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Model.BusinessModel
{
    public class BossBM
    {
        /// <summary>
        /// PK
        /// </summary>
        public System.Guid BossID { get; set; }

        /// <summary>
        /// 順序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Boss名稱
        /// </summary>
        public string Name { get; set; }
    }
}