using AutoMapper;
using PRCN.Clan.DB;
using PRCN.Clan.Model.ApiModel.AttackRecord;
using PRCN.Clan.Model.BusinessModel;
using PRCN.Clan.Service.Interface;
using PRCN.Clan.Service.Repository;
using PRCN.Clan.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PRCN.Clan.Service.Service
{
    public class AttackRecordService : BaseService<AttackRecord>, IAttackRecordService, IDisposable
    {
        IMapper mapper;

        public AttackRecordService(IUnitOfWork unitOfWork, IMapper iMapper, IGenericRepository<AttackRecord> repository) : base(unitOfWork, repository)
        {
            mapper = iMapper;
        }

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        public async Task<bool> Add(AttackRecordBM bm)
        {
            var instance = mapper.Map<AttackRecord>(bm);
            return await Create(instance);
        }
        #endregion

        #region 修改資料
        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        public async Task<bool> Edit(AttackRecordBM bm)
        {
            var instance = mapper.Map<AttackRecord>(bm);
            return await Update(instance, instance.AttackRecordID);
        }
        #endregion

        #region 刪除多筆資料
        /// <summary>
        /// 刪除多筆資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteRange(Guid[] ids)
        {
            var entity = FindBy(x => ids.Contains(x.AttackRecordID));
            return DeleteGroup(entity.ToList());
        }
        #endregion

        #region 取得所有資料AM
        /// <summary>
        /// 取得所有資料AM
        /// </summary>
        /// <returns></returns>
        public async Task<List<AttackRecordAM>> GetAllAM()
        {
            var entity = await GetAll();
            entity = entity.OrderByDescending(x => x.CreateDatetime);
            var result = mapper.Map<List<AttackRecordAM>>(entity);
            return result;
        }
        #endregion

        #region 依GUID取得資料
        /// <summary>
        /// 依GUID取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AttackRecordBM GetByID(Guid id)
        {
            var entity = GetById(id);
            var result = mapper.Map<AttackRecordBM>(entity);
            return result;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~EmployeeService() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}