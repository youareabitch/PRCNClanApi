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
    public class MemberController : BaseController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiReturnModel> Add(MemberBM bm)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                bm.MemberID = Guid.NewGuid();

                msg.result = await _memberService.Add(bm);
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
        public async Task<ApiReturnModel> Edit(MemberBM bm)
        {
            ApiReturnModel msg = new ApiReturnModel();

            try
            {
                var editModel = _memberService.GetByID(bm.MemberID);

                editModel.ID = bm.ID;
                editModel.Name = bm.Name;
                editModel.Memo = bm.Memo;

                msg.result = await _memberService.Edit(editModel);
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
                msg.result = _memberService.DeleteRange(ids);
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
                msg.data = await _memberService.GetAllAM();
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
                msg.data = await _memberService.GetAllBM();
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
                msg.data = _memberService.GetByID(id);
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
