using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCN.Clan.Service.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        int SaveChange();
    }
}
