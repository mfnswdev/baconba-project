using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class GetWeightsRequestHandler : IRequestHandler<GetWeightsRequest, Result<GetWeightsResponse>>
{
    private readonly IWeightRepository _weightRepository;
    private readonly ILogger<GetWeightsRequestHandler> _logger;
    public GetWeightsRequestHandler(IWeightRepository weightRepository, ILogger<GetWeightsRequestHandler> logger)
    {
        _weightRepository = weightRepository;
        _logger = logger;
    }
    public async Task<Result<GetWeightsResponse>> Handle(GetWeightsRequest request, CancellationToken cancellationToken)
    {
        var response = await _weightRepository.GetWeightsAsync(request.Eartag);

        if (response == null || !response.Any())
        {
            return Result.Error<GetWeightsResponse>(new Exception("Animals not found"));
        }

        var convertedResponse = new GetWeightsResponse
        {
            Weights = new List<GetWeightResponse>()
        };

        foreach (var weight in response)
        {
            if (weight != null)
            {
                convertedResponse.Weights.Add(new GetWeightResponse
                {
                    Eartag = weight.Animal.Eartag,
                    Date = weight.Date,
                    WeightValue = weight.WeightValue
                });
            }
        }
        return Result.Success(convertedResponse);
    }
}
