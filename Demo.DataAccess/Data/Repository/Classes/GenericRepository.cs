using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository.Interfaces;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.Shared;

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

        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
         

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }



        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

      
    }








}
