using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.RemoveCommand;

public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnalysisHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisRemove",new { request.AnalysisId });
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