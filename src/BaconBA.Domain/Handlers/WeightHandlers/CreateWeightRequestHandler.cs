using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class CreateWeightRequestHandler : IRequestHandler<CreateWeightRequest, Result<CreateWeightResponse>>
{
    public readonly IWeightRepository _weightRepository;
    public readonly IAnimalRepository _animalRepository;
    public readonly ILogger<CreateWeightRequestHandler> _logger;
    public CreateWeightRequestHandler(IWeightRepository weightRepository, IAnimalRepository animalRepository, ILogger<CreateWeightRequestHandler> logger)
    {
        _weightRepository = weightRepository;
        _animalRepository = animalRepository;
        _logger = logger;
    }
    public async Task<Result<CreateWeightResponse>> Handle(CreateWeightRequest request, CancellationToken cancellationToken)
    {
        var response = await _animalRepository.GetAnimalAsync(request.Eartag);
        if (response == null)
        {
            return Result.Error<CreateWeightResponse>(new Exception("Animal not found"));
        }
        else
        {
            var weightEntity = new Weight
            {
                AnimalId = response.Id,
                Date = request.Date,
                WeightValue = request.WeightValue,
                Animal = response

            };
            var result = await _weightRepository.AddWeightAsync(weightEntity);
            if (result == null)
            {
                return Result.Error<CreateWeightResponse>(new Exception("Weight not created"));
            }
            else
            {
                return Result.Success<CreateWeightResponse>(new CreateWeightResponse
                {
                    Eartag = request.Eartag,
                    Date = result.Date,
                    WeightValue = result.WeightValue
                });
            }
        }

    }
}

