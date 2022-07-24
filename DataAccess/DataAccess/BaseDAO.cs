using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BaseDAO<TEntity> : IBaseDAO<TEntity> where TEntity : class
    {
        public static BaseDAO<TEntity>? instance;
        public static readonly object instanceLock = new();

        public BaseDAO() { }

        public static BaseDAO<TEntity> Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BaseDAO<TEntity>();
                    }
                    return instance;
                }
            }
        }

        public virtual bool DeleteEntity(TEntity entity)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    db.Set<TEntity>().Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public virtual IEnumerable<TEntity>? GetAllEntity()
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    return db.Set<TEntity>().ToList();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public virtual TEntity? GetEntityById(int? entityID)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    var result = ((IQueryable<IEntityWithId>)db.IncludeAll<TEntity>()).FirstOrDefault(s => s.Id == entityID);
                    return result as TEntity;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public virtual bool SaveEntity(TEntity entity)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    db.Set<TEntity>().Add(entity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public virtual bool UpdateEntity(TEntity entity)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    db.Set<TEntity>().Update(entity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
    }
    public static class EntityFrameworkQueryableExtensions
    {
        public static IQueryable<TEntity> IncludeAll<TEntity>(this SaleManagementDBContext source) where TEntity : class
        {
            var query = source.Set<TEntity>().AsQueryable();

            foreach (var property in source.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            return query;
        }
    }
}
