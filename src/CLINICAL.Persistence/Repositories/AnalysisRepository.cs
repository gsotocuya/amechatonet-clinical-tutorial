using System.Data;
using CLINICAL.Application.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;

namespace CLINICAL.Persistence.Repositories;

public class AnalysisRepository : IAnalysisRepository
{
    private readonly ApplicationDbContext _context;

    public AnalysisRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Analysis>> ListAnalysis()
    {
        using var connection = _context.CreateConnection;
        var query = "uspAnalysisList";
        var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);
        return analysis;
    }
}