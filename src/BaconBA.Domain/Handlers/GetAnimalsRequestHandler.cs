using BaconBA.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain;

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
        if (response == null)
        {
            return Result.Error<GetAnimalsResponse>(new Exception("Animals not found"));
        }
        else
        {
            var convertedResponse = new GetAnimalsResponse();
            response.ForEach(x => convertedResponse.Animals.Add(new GetAnimalResponse() { Eartag = x.Eartag, BirthDate = x.BirthDate, Status = x.Status, Gender = x.Gender }));
            return Result.Success(convertedResponse);
        }
    }
}
