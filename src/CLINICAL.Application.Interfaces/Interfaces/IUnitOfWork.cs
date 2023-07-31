using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Analysis> Analysis { get; }
}