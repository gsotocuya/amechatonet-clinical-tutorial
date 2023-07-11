using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;

public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
{
    private readonly IAnalysisRepository _analysisRepository;
    private readonly IMapper _mapper;

    public AnalysisByIdHandler(IAnalysisRepository analysisRepository, IMapper mapper)
    {
        _analysisRepository = analysisRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetAnalysisByIdResponseDto>();
        try
        {
            var analysis = await _analysisRepository.AnalysisById(request.AnalysisId);
            if (analysis is null)
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
            response.Message = "Consulta Exitosa!!!";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}