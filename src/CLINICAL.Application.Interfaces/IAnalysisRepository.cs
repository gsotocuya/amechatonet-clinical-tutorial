using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces;

public interface IAnalysisRepository
{
    Task<IEnumerable<Analysis>> ListAnalysis();
    Task<Analysis> AnalysisById(int analysisId);
}