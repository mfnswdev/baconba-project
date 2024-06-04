using BaconBA.Shared;
using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class GetAnimalsRequestHandler : IRequestHandler<GetAnimalsRequest, Result<GetAnimalsResponse>>
{
    private readonly ILogger<GetAnimalsRequestHandler> _logger;
    private readonly IAnimalRepository _animalRepository;

    public GetAnimalsRequestHandler(ILogger<GetAnimalsRequestHandler> logger, IAnimalRepository animalRepository)
    {
        _logger = logger;
        _animalRepository = animalRepository;
    }
    public async Task<Result<GetAnimalsResponse>> Handle(GetAnimalsRequest request, CancellationToken cancellationToken)
    {
        var response = await _animalRepository.GetAnimalsAsync();

        if (response == null || !response.Any())
        {
            return Result.Error<GetAnimalsResponse>(new Exception("Animals not found"));
        }

        var convertedResponse = new GetAnimalsResponse
        {
            Animals = new List<GetAnimalResponse>()
        };

        foreach (var animal in response)
        {
            if (animal != null)
            {
                convertedResponse.Animals.Add(new GetAnimalResponse
                {
                    Eartag = animal.Eartag,
                    BirthDate = animal.BirthDate,
                    Status = animal.Status,
                    Gender = animal.Gender
                });
            }
        }

        return Result.Success(convertedResponse);
    }

}
