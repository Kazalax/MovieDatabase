using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movies.Data.Interfaces;

namespace Movies.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MoviesDbContext moviesDbContext;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(MoviesDbContext moviesDbContext)
        {
            this.moviesDbContext = moviesDbContext;
            dbSet = moviesDbContext.Set<TEntity>();
        }

        public TEntity? FindById(uint id)
        {
            return dbSet.Find(id);
        }

        public bool ExistsWithId(uint id)

        {
            TEntity? entity = dbSet.Find(id);
            // Abychom se vyhnuli problémům se sledováním více entit se stejným ID
            if (entity is not null)
                moviesDbContext.Entry(entity).State = EntityState.Detached;
            return entity is not null;
        }

        public IList<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = dbSet.Add(entity);
            moviesDbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = dbSet.Update(entity);
            moviesDbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(uint id)
        {
            TEntity? entity = dbSet.Find(id);
            if (entity is not null)
            {
                dbSet.Remove(entity);
                moviesDbContext.SaveChanges();
            }
        }
    }
}
