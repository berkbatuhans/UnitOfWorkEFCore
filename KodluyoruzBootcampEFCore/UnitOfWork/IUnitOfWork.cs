using System;
using System.Threading.Tasks;
using KodluyoruzBootcampEFCore.DAL.Entities.Core;
using KodluyoruzBootcampEFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace KodluyoruzBootcampEFCore.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        Task<int> Commit();
        void Rollback();

    }
}
