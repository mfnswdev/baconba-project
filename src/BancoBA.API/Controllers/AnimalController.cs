using BaconBA.API.Controllers;
using BaconBA.Shared;
using BaconBA.Shared.Exceptions;
using BaconBA.Shared.Requests;
using BaconBA.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaconBA.API;

[ApiController]
[Route("v1/[controller]")]
public class AnimalController : BaseController
{
    private readonly ILogger<AnimalController> _logger;
    private readonly IMediator _mediator;

    public AnimalController(ILogger<AnimalController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateAnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateAnimalResponse>> AddAnimalAsync(
        [FromBody] CreateAnimalRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(UpdateAnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateAnimalResponse>> UpdateAnimalAsync(
        [FromBody] UpdateAnimalRequest request) => await SendCommand(request);

    [HttpGet("{Eartag}")]
    [ProducesResponseType(typeof(GetAnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAnimalResponse>> GetAnimalAsync(
        [FromRoute] GetAnimalRequest request) => await SendCommand(request);

    [HttpGet("All")]
    [ProducesResponseType(typeof(GetAnimalsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAnimalsResponse>> GetAnimalsAsync(
        [FromHeader] GetAnimalsRequest request) => await SendCommand(request);



    [HttpDelete("{Eartag}")]
    [ProducesResponseType(typeof(DeleteAnimalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteAnimalResponse>> DeleteAnimalAsync(
        [FromRoute] DeleteAnimalRequest request) => await SendCommand(request);
}
