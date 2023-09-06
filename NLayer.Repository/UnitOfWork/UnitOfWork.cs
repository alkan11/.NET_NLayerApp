using NlayerCoreApp.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppdbContext _appdbContext;

        public UnitOfWork(AppdbContext appdbContext)
        {
            _appdbContext = appdbContext;
        }

        public void Commit()
        {
            _appdbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appdbContext.SaveChangesAsync();
        }
    }
}
