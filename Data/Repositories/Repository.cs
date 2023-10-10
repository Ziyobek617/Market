using Market.Data.IRepository;
using Market.DbContexts;
using Market.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    AppDbContext dbContext;
    DbSet<TEntity> dbset;
    public Repository()
    {
        dbContext = new AppDbContext();
        this.dbset = dbContext.Set<TEntity>();
    }
    public async Task<bool> DeleteAsync(long Id)
    {
        var entity = await dbset.FirstOrDefaultAsync(x => x.Id == Id);
        dbset.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await dbset.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> SelectAll()
        => this.dbset;

    public async Task<TEntity> SelectByIdAsync(long Id)
        => await dbset.FirstOrDefaultAsync(x => x.Id ==Id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var model = (dbContext.Update(entity)).Entity;
        await dbContext.SaveChangesAsync();
        return model;
    }
}
