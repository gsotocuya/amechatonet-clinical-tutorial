using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings;

public class AnalysisMappingsProfile : Profile
{
    public AnalysisMappingsProfile()
    {
        CreateMap<Analysis, GetAllAnalysisResponseDto>()
            .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Analysis, GetAnalysisByIdResponseDto>()
            .ReverseMap();
    }
}