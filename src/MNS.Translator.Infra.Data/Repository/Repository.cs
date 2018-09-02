using MNS.Translator.Domain.Interfaces.Repository;
using MNS.Translator.Domain.Models;
using MNS.Translator.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MNS.Translator.Infra.Data.Repository
{
    public class Repository<TEntity> : ITranslationRequestRepository<TEntity> where TEntity : Entity<TEntity>, new()
    {
        protected TranslatorContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(TranslatorContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            return objReturn;
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Delete(Guid id)
        {
            var obj = new TEntity { Id = id };
            DbSet.Remove(obj);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
