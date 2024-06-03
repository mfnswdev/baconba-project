namespace BaconBA.Domain;

public interface IWeightRepository
{

    Task<List<Weight>> GetWeightsAsync(string eartag); 
    Task<Weight> GetWeightAsync(int id);
    Task<Weight> AddWeightAsync(Weight weight);
    Task<Weight> UpdateWeightAsync(Weight weight);
    Task<Weight> DeleteWeightAsync(int id);

}
