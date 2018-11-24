using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Model.BusinessModel
{
    public class AttackRecordBM
    {
        /// <summary>
        /// PK
        /// </summary>
        public System.Guid AttackRecordID { get; set; }

        /// <summary>
        /// FK - 戰隊成員GUID
        /// </summary>
        public System.Guid MemberID { get; set; }

        /// <summary>
        /// FK - BOSS GUID
        /// </summary>
        public System.Guid BossID { get; set; }

        /// <summary>
        /// 出刀日期
        /// </summary>
        public System.DateTime AttackDate { get; set; }

        /// <summary>
        /// 周回數 (1或2)
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// 傷害
        /// </summary>
        public decimal Damage { get; set; }

        /// <summary>
        /// 是否尾刀
        /// </summary>
        public bool IsKillSteal { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 資料建立時間
        /// </summary>
        public Nullable<System.DateTime> CreateDatetime { get; set; }
    }
}