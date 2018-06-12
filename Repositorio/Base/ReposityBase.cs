using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Base
{
    public class ReposityBase<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext Context;
        private DbSet<TEntity> DBSet => Context.Set<TEntity>();

        public ReposityBase(AppDbContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> GetAll() => DBSet;

        public void Add(TEntity entity) => DBSet.Add(entity);

        public TEntity GetById(int id) => DBSet.FirstOrDefault(f => f.Id == id);

        public void Delete(TEntity entity) => DBSet.Remove(entity);

        public bool Exists(int id) => DBSet.Any(a => a.Id == id);

        public bool SaveChanges() => Context.SaveChanges() >= 0;
    }
}
