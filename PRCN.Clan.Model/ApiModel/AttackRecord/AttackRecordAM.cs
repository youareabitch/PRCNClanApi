using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Model.ApiModel.AttackRecord
{
    public class AttackRecordAM
    {
        /// <summary>
        /// PK
        /// </summary>
        public System.Guid AttackRecordID { get; set; }

        /// <summary>
        /// 戰隊成員名稱
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 戰隊成員UID
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// BOSS名稱
        /// </summary>
        public string BossName { get; set; }

        /// <summary>
        /// 出刀日期
        /// </summary>
        public string AttackDate { get; set; }

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
        public string IsKillSteal { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
    }
}