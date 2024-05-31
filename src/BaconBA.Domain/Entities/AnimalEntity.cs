using BaconBA.Shared;

namespace BaconBA.Domain;

public class AnimalEntity
{
    public int Id {get; set;} 
    public string Eartag {get; set;} = default!;
    public string GenitorEartag {get; set;} = default!;
    public string MatriarchEartag {get; set;} = default!;
    public DateTime BirthDate {get; set;}
    public DateTime CheckoutDate {get; set;}
    public string Status {get; set;} = default!;
    public string Gender {get; set;} = default!;
    public ICollection<WeightEntity> Weights {get; set;} = default!;

    internal void Update(DateTime BirthDate, DateTime CheckoutDate, string Eartag, string GenitorEartag, string MatriarchEartag, string Status, string Gender)
    {
        this.BirthDate = BirthDate;
        this.CheckoutDate = CheckoutDate;
        this.Eartag = Eartag;
        this.GenitorEartag = GenitorEartag;
        this.MatriarchEartag = MatriarchEartag;
        this.Status = Status;
        this.Gender = Gender;
    }

}
