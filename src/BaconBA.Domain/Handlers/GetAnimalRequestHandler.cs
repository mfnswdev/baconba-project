using BaconBA.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain;

public class GetAnimalRequestHandler : IRequestHandler<GetAnimalRequest, Result<GetAnimalResponse>>
{
    private readonly ILogger<GetAnimalRequestHandler> _logger;
    private readonly IAnimalRepository _animalRepository;

    public GetAnimalRequestHandler(ILogger<GetAnimalRequestHandler> logger, IAnimalRepository animalRepository){
        _logger = logger;
        _animalRepository = animalRepository;
    }
    public async Task<Result<GetAnimalResponse>> Handle(GetAnimalRequest request, CancellationToken cancellationToken)
    {
        var response = await _animalRepository.GetAnimalAsync(request.Eartag);
        if (response == null)
        {
            return Result.Error<GetAnimalResponse>(new Exception("Animal not found"));
        }
        else
        {
            return Result.Success<GetAnimalResponse>(new GetAnimalResponse()
            {
                Eartag = response.Eartag,
                BirthDate = response.BirthDate,
                Status = response.Status,
                Gender = response.Gender
            });
        }
    }
}
