using PRCN.Clan.DB;
using PRCN.Clan.Model.ApiModel.AttackRecord;
using PRCN.Clan.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCN.Clan.Service.Interface
{
    public interface IAttackRecordService : IBaseService<AttackRecord>
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        Task<bool> Add(AttackRecordBM bm);

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        Task<bool> Edit(AttackRecordBM bm);

        /// <summary>
        /// 刪除多筆資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteRange(Guid[] ids);

        /// <summary>
        /// 取得所有資料AM
        /// </summary>
        /// <returns></returns>
        Task<List<AttackRecordAM>> GetAllAM();

        /// <summary>
        /// 依ID取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AttackRecordBM GetByID(Guid id);
    }
}
