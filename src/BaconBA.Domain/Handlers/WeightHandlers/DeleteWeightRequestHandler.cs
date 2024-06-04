using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class DeleteWeightRequestHandler : IRequestHandler<DeleteWeightRequest, Result<DeleteWeightResponse>>
{
    private readonly IWeightRepository _weightRepository;

    private readonly ILogger<DeleteWeightRequestHandler> _logger;
    public DeleteWeightRequestHandler(IWeightRepository weightRepository, ILogger<DeleteWeightRequestHandler> logger)
    {
        _weightRepository = weightRepository;
        _logger = logger;
    }
    public async Task<Result<DeleteWeightResponse>> Handle(DeleteWeightRequest request, CancellationToken cancellationToken)
    {
        var response = await _weightRepository.GetWeightAsync(request.Id);
        if (response == null)
        {
            return Result.Error<DeleteWeightResponse>(new Exception("Weight not found"));
        }
        else
        {
            await _weightRepository.DeleteWeightAsync(response.Id);
            return Result.Success<DeleteWeightResponse>(new DeleteWeightResponse
            {
                Eartag = response.Animal.Eartag,
                Date = response.Date,
                WeightValue = response.WeightValue
            });
        }
    }
}
