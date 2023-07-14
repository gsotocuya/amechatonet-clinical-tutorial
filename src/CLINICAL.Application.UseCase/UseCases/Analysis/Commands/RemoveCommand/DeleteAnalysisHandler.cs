using AutoMapper;
using CLINICAL.Application.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.RemoveCommand;

public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
{
    private readonly IAnalysisRepository _analysisRepository;

    public DeleteAnalysisHandler(IAnalysisRepository analysisRepository)
    {
        _analysisRepository = analysisRepository;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            response.Data = await _analysisRepository.AnalysisRemove(request.AnalysisId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación Exitosa";
                return response;
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}