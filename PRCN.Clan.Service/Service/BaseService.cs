using PRCN.Clan.Service.Interface;
using PRCN.Clan.Service.Repository;
using PRCN.Clan.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace PRCN.Clan.Service.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        protected IGenericRepository<TEntity> _repository { get; set; }

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public virtual async Task<bool> Create(TEntity entity)
        {
            var result = await _repository.Create(entity);
            return result;
        }

        public virtual async Task<bool> Update(TEntity entity, params object[] keyValues)
        {
            bool result = false;
            if (null != entity)
            {
                result = await _repository.Update(entity, keyValues);
            }
            return result;
        }

        public virtual bool Delete(Guid id)
        {
            bool result = false;
            var entity = _repository.GetById(id);
            _repository.Delete(entity);
            _repository.UnitOfWork.SaveChange();
            result = true;
            return result;
        }

        public virtual bool DeleteGroup(IList<TEntity> entities)
        {
            bool result = false;
            _repository.DeleteRange(entities);
            result = true;
            return result;
        }

        public virtual Task<IQueryable<TEntity>> GetAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public virtual TEntity GetById(Guid id)
        {
            var result = _repository.GetById(id);
            return result;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }
    }
}