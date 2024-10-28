using Microsoft.EntityFrameworkCore;

namespace degree_management.constracts.Abstractions;

public interface IUnitOfWord : IDisposable
{
    Task<int> CommitAsync();
}

public interface IUnitOfWork<TContext> : IUnitOfWord where TContext : DbContext
{}