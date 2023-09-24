using Homee.DataAccess.Data;
using Homee.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    internal DbSet<T> dbSet;
    public Repository(AppDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        return await query.FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
    }

    public async Task<T> GetDetailsAsync(int id)
    {
        var data = await dbSet.FindAsync(id);
        return data;
    }



    public async void RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRangeAsync(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }

    public Task SaveAsync()
    {
        return _db.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
