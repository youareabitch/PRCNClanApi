using PRCN.Clan.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRCN.Clan.Service.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; set; }

        Task<bool> Create(TEntity instance);

        /// <summary>
        /// AddRange
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The instance.</param>
        Task<bool> AddRange(IList<TEntity> entities);

        void Delete(TEntity instance);

        /// <summary>
        /// 多筆刪除
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IList<TEntity> entities);

        //void Dispose();
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<System.Linq.IQueryable<TEntity>> GetAll();
        Task<bool> Update(TEntity instance, params object[] keyValues);
        TEntity GetById(Guid id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
