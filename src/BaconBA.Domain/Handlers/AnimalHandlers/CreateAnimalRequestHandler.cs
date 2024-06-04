using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace BaconBA.Domain.Handlers;

public class CreateAnimalRequestHandler : IRequestHandler<CreateAnimalRequest, Result<CreateAnimalResponse>>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly ILogger<CreateAnimalRequestHandler> _logger;
    public CreateAnimalRequestHandler(IAnimalRepository animalRepository, ILogger<CreateAnimalRequestHandler> logger)
    {
        _animalRepository = animalRepository;
        _logger = logger;
    }
    public async Task<Result<CreateAnimalResponse>> Handle(CreateAnimalRequest request, CancellationToken cancellationToken)
    {
        var animalEntity = new AnimalEntity()
        {
            Eartag = request.Eartag,
            GenitorEartag = request.GenitorEartag,
            MatriarchEartag = request.MatriarchEartag,
            BirthDate = request.BirthDate,
            CheckoutDate = request.CheckoutDate,
            Status = request.Status,
            Gender = request.Gender
        };

        var response = await _animalRepository.AddAnimalAsync(animalEntity);
        if (response == null)
        {
            return Result.Error<CreateAnimalResponse>(new Exception("Animal not created"));
        }
        else
        {
            return Result.Success<CreateAnimalResponse>(new CreateAnimalResponse
            {
                Eartag = response.Eartag,
                BirthDate = response.BirthDate,
                Status = response.Status,
                Gender = response.Gender
            });
        }
    }
}
