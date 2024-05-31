namespace BaconBA.Domain;

public class HealthcareSessionEntity
{
    public int Id {get; set;} 
    public DateTime SessionDate {get; set;}
    public string SessionDescription {get; set;} = default!;
    public string SessionStatus {get; set;} = default!;
    public ICollection<AnimalEntity> Animals {get; set;} = default!;
    public ICollection<SessionActivity> Activities {get; set;} = default!;
}

public class SessionActivity{

    public string AnimalEartag {get; set;} = default!;
    public bool Done {get; set;} = false;
    public string Name {get; set;} = default!;

}