using MNS.Translator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MNS.Translator.Domain.Interfaces.Repository
{
    public interface ITranslationRequestRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        void Delete(Guid id);
        int SaveChanges();
    }
}
