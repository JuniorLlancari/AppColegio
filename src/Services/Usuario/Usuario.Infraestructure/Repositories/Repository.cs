using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Abstractions;

namespace Usuario.Infraestructure.Repositories;

internal abstract class Repository<T>
where T : Entity
{
    protected readonly ApplicationDbContext dbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        return await dbContext.Set<T>()
        .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public async Task<List<T>> ListAsync(
        CancellationToken cancellationToken
    )
    {
        return await dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public void Add(T entity)
    {
        dbContext.Add(entity);
    }

    public void Update(T entity)
    {
        dbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        dbContext.Remove(entity);
    }


}