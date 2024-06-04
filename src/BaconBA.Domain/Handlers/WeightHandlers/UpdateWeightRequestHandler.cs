using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class UpdateWeightRequestHandler : IRequestHandler<UpdateWeightRequest, Result<UpdateWeightResponse>>
{
    public readonly IWeightRepository _weightRepository;
    public readonly ILogger<UpdateWeightRequestHandler> _logger;
    public UpdateWeightRequestHandler(IWeightRepository weightRepository, ILogger<UpdateWeightRequestHandler> logger)
    {
        _weightRepository = weightRepository;
        _logger = logger;
    }
    public async Task<Result<UpdateWeightResponse>> Handle(UpdateWeightRequest request, CancellationToken cancellationToken)
    {
        var response = await _weightRepository.GetWeightAsync(request.Id);
        if (response == null)
        {
            return Result.Error<UpdateWeightResponse>(new Exception("Weight not found"));
        }
        else
        {
            response.Update(request.Date,
                            request.WeightValue);
            await _weightRepository.UpdateWeightAsync(response);
            return Result.Success<UpdateWeightResponse>(new UpdateWeightResponse
            {
                Eartag = response.Animal.Eartag,
                Date = response.Date,
                WeightValue = response.WeightValue
            });
        }
    }
}
