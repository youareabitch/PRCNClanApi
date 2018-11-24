using PRCN.Clan.Api.Helper;
using PRCN.Clan.Model.ApiModel;
using PRCN.Clan.Model.BusinessModel;
using PRCN.Clan.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PRCN.Clan.Api.Controllers
{
    public class AttackRecordController : BaseController
    {
        private readonly IAttackRecordService _attackRecordService;

        public AttackRecordController(IAttackRecordService attackRecordService)
        {
            _attackRecordService = attackRecordService;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiReturnModel> Add(AttackRecordBM bm)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                bm.AttackRecordID = Guid.NewGuid();

                msg.result = await _attackRecordService.Add(bm);
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = Common.GetErrorMessage(ex);
            }

            return msg;
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiReturnModel> Edit(AttackRecordBM bm)
        {
            ApiReturnModel msg = new ApiReturnModel();
            //test
            try
            {
                var editModel = _attackRecordService.GetByID(bm.AttackRecordID);

                editModel.MemberID = bm.MemberID;
                editModel.BossID = bm.BossID;
                editModel.Damage = bm.Damage;
                editModel.AttackDate = bm.AttackDate;
                editModel.Memo = bm.Memo;
                editModel.Round = bm.Round;
                editModel.IsKillSteal = bm.IsKillSteal;

                msg.result = await _attackRecordService.Edit(editModel);
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = Common.GetErrorMessage(ex);
            }

            return msg;
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiReturnModel DeleteRange(Guid[] ids)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                msg.result = _attackRecordService.DeleteRange(ids);
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = Common.GetErrorMessage(ex);
            }

            return msg;
        }



        /// <summary>
        /// 取得所有資料AM
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiReturnModel> GetAllAM()
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                msg.data = await _attackRecordService.GetAllAM();
                msg.result = true;
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = Common.GetErrorMessage(ex);
            }

            return msg;
        }

        /// <summary>
        /// 依GUID取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiReturnModel GetByID(Guid id)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                msg.data = _attackRecordService.GetByID(id);
                msg.result = true;
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = Common.GetErrorMessage(ex);
            }

            return msg;
        }
    }
}
