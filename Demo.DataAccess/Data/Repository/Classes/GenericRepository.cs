using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.Shared;
using System.Linq.Expressions;

namespace Demo.DataAccess.Data.Repository.Classes
{







    public class GenericRepository<TEntity> (ApplicationDbContext _dbContext): IGenericRepository<TEntity> where TEntity : BaseEntity
    {



        






        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false).ToList();
            }

            else return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false).AsNoTracking().ToList();



        }







        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

        void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
         

         void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }



         void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }



        public IEnumerable<TEntity> GetIEnumerable()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetIQueryable()
        {
            return _dbContext.Set<TEntity>();
        }



        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false)
                .Select(selector).ToList(); 


        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {

            return _dbContext.Set<TEntity>().Where(predicate).Where(entity => entity.IsDeleted == false).ToList();

        }

        void IGenericRepository<TEntity>.Add(TEntity entity)
        {
            Add(entity);
        }

        void IGenericRepository<TEntity>.Remove(TEntity entity)
        {
            Remove(entity);
        }

        void IGenericRepository<TEntity>.Update(TEntity entity)
        {
            Update(entity);
        }
    }








}
