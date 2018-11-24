using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRCN.Clan.Service.Interface
{
    public interface IBaseService<TEntity>
    {
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity, params object[] keyValues);
        //bool UpdateOnly(TEntity entity);
        bool Delete(Guid id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<System.Linq.IQueryable<TEntity>> GetAll();
        TEntity GetById(Guid id);
    }
}
