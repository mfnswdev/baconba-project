using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class GetWeightRequestHandler : IRequestHandler<GetWeightRequest, Result<GetWeightResponse>>
{
    private readonly IWeightRepository _weightRepository;
    private readonly ILogger<GetWeightRequestHandler> _logger;
    public GetWeightRequestHandler(IWeightRepository weightRepository, ILogger<GetWeightRequestHandler> logger)
    {
        _weightRepository = weightRepository;
        _logger = logger;
    }
    public async Task<Result<GetWeightResponse>> Handle(GetWeightRequest request, CancellationToken cancellationToken)
    {
        var response = await _weightRepository.GetWeightAsync(request.Id);
        if (response == null)
        {
            return Result.Error<GetWeightResponse>(new Exception("Weight not found"));
        }
        else
        {
            return Result.Success<GetWeightResponse>(new GetWeightResponse
            {
                Eartag = response.Animal.Eartag,
                Date = response.Date,
                WeightValue = response.WeightValue
            });
        }
    }
}
