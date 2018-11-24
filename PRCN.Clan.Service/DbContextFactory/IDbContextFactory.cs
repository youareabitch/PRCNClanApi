using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCN.Clan.Service.DbContextFactory
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}
