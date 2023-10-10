namespace Market.Data.IRepository;

public interface IRepository<TEntity>
{
    public Task<bool> DeleteAsync(long Id);
    public Task<TEntity> SelectByIdAsync(long Id);
    public Task<TEntity> InsertAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public IQueryable<TEntity> SelectAll();
}
