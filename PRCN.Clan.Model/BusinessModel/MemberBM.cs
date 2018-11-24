using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Model.BusinessModel
{
    public class MemberBM
    {
        /// <summary>
        /// PK
        /// </summary>
        public System.Guid MemberID { get; set; }

        /// <summary>
        /// UID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 遊戲暱稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
    }
}