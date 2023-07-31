namespace CLINICAL.Application.Interfaces.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllASync(string storedProcedure);
    Task<T> GetByIdAsync(string storedProcedure, object parameter);
    Task<bool> ExecAsync(string storedProcedure, object parameter);
    
}