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
    public class BossController : BaseController
    {
        private readonly IBossService _bossService;

        public BossController(IBossService bossService)
        {
            _bossService = bossService;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiReturnModel> Add(BossBM bm)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                bm.BossID = Guid.NewGuid();

                msg.result = await _bossService.Add(bm);
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
        public async Task<ApiReturnModel> Edit(BossBM bm)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                var editModel = _bossService.GetByID(bm.BossID);

                editModel.Order = bm.Order;
                editModel.Name = bm.Name;

                msg.result = await _bossService.Edit(editModel);
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
                msg.result = _bossService.DeleteRange(ids);
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
                msg.data = await _bossService.GetAllAM();
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
        /// 取得所有資料BM
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiReturnModel> GetAllBM()
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                msg.data = await _bossService.GetAllBM();
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
                msg.data = _bossService.GetByID(id);
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
