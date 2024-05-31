using BaconBA.Shared.Enums;

namespace BaconBA.Shared.Exceptions;
public class ErrorResult
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETypeError Tipo { get; set; }
}
