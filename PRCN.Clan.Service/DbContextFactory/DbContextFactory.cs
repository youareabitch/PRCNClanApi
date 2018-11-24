using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Service.DbContextFactory
{
    public class DbContextFactory : IDbContextFactory
    {
        private string _ConnectionString = string.Empty;

        public DbContextFactory(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        public DbContextFactory() { }

        private DbContext _dbContext;
        private DbContext dbContext
        {
            get
            {
                if (this._dbContext == null)
                {
                    //Type t = typeof(ApplicationDbContext);
                    //_dbContext = (ApplicationDbContext)Activator.CreateInstance(t, new[] { _ConnectionString });                    
                    //_dbContext = (ApplicationDbContext)Activator.CreateInstance(t);
                    //_dbContext = new DbContext(_ConnectionString);

                    Type t = typeof(DbContext);
                    this._dbContext = (DbContext)Activator.CreateInstance(t, this._ConnectionString);
                }
                return _dbContext;
            }
        }

        public DbContext GetDbContext()
        {
            return this.dbContext;
        }
    }
}