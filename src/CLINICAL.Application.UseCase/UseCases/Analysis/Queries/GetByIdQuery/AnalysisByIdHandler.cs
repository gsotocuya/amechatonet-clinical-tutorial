using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;

public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetAnalysisByIdResponseDto>();
        try
        {
            var analysis = await _unitOfWork.Analysis.GetByIdAsync(SP.uspAnalysisById, request);
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