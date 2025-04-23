using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;


public class BaseRepository<T>:IRepository<T> where T:class
{
    private readonly EcommerceDbContext _dbcontext;
    public BaseRepository(EcommerceDbContext dbContext)
    {
     this._dbcontext = dbContext;   
    }
    public int Insert(T entity)
    {
        _dbcontext.Set<T>().Add(entity);
        return _dbcontext.SaveChanges();
    }

    public int Update(T entity)
    {
        _dbcontext.Set<T>().Entry(entity).State = EntityState.Modified;
return _dbcontext.SaveChanges();
    }

    public int Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbcontext.Set<T>().Remove(entity);
        }
        return _dbcontext.SaveChanges();
    }

    public T GetById(int id)
    {
return _dbcontext.Set<T>().Find(id);

    }

    public IEnumerable<T> GetAll()
    {
        return _dbcontext.Set<T>();
    }
}