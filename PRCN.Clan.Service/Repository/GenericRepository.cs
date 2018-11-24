using PRCN.Clan.DB;
using PRCN.Clan.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace PRCN.Clan.Service.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public DbContext _context { get; set; }

        private DbSet<TEntity> _dbSet { get; set; }


        public GenericRepository()
        {
            this._context = new PRCNClanEntities();
        }

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this._context = unitOfWork.Context;
            this._dbSet = unitOfWork.Context.Set<TEntity>();
        }

        /// <summary>
        /// Creates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.ArgumentNullException">instance</exception>
        public async Task<bool> Create(TEntity instance)
        {
            var bl = false;

            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                _context.Set<TEntity>().Add(instance);

                int i = 0;
                await Task.Run(() =>
                {
                    i = SaveChanges().Result;
                }).ConfigureAwait(false); //加設ConfigureAwait;

                if (i > 0) bl = true;
            }

            return bl;
        }

        /// <summary>
        /// AddRange
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The instance.</param>
        public async Task<bool> AddRange(IList<TEntity> entities)
        {

            var bl = false;

            if (entities == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                _context.Set<TEntity>().AddRange(entities);

                int i = 0;
                await Task.Run(() =>
                {
                    i = SaveChanges().Result;
                }).ConfigureAwait(false); //加設ConfigureAwait;

                if (i > 0) bl = true;
            }

            return bl;
        }

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="keyValues">The key values.</param>
        /// <exception cref="System.ArgumentNullException">instance</exception>
        public async Task<bool> Update(TEntity instance, params object[] keyValues)
        {
            var bl = false;
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            var entry = _context.Entry<TEntity>(instance);

            if (entry.State == EntityState.Detached)
            {
                var set = _context.Set<TEntity>();

                TEntity attachedEntity = set.Find(keyValues);

                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(instance);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            //int x = await this.SaveChanges();
            int i = 0;
            await Task.Run(() =>
            {
                //Task.Delay(1000);
                i = SaveChanges().Result;
            }).ConfigureAwait(false); //加設ConfigureAwait;

            if (i > 0) bl = true;

            return bl;
        }

        /// <summary>
        /// Deletes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public async void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Entry(instance).State = EntityState.Deleted;
                await this.SaveChanges();
            }
        }

        /// <summary>
        /// 多筆刪除
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteRange(IList<TEntity> entities)
        {
            if (entities.Count == 0)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                foreach (var item in entities)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<IQueryable<TEntity>> GetAll()
        {
            var result = await _context.Set<TEntity>().AsQueryable().ToListAsync();
            if (result != null)
            {
                return result.AsQueryable();
            }
            return null;
        }

        public virtual TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async System.Threading.Tasks.Task<int> SaveChanges()
        {
            var i = await _context.SaveChangesAsync();
            return i;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}