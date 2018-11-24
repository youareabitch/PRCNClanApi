using PRCN.Clan.DB;
using PRCN.Clan.Model.ApiModel.Member;
using PRCN.Clan.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCN.Clan.Service.Interface
{
    public interface IMemberService : IBaseService<Member>
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        Task<bool> Add(MemberBM bm);

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        Task<bool> Edit(MemberBM bm);

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
        Task<List<MemberAM>> GetAllAM();

        /// <summary>
        /// 取得所有資料AM
        /// </summary>
        /// <returns></returns>
        Task<List<MemberBM>> GetAllBM();

        /// <summary>
        /// 依ID取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MemberBM GetByID(Guid id);
    }
}
