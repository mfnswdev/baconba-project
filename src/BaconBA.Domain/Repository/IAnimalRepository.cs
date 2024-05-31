namespace BaconBA.Domain;

public interface IAnimalRepository
{

    Task<List<AnimalEntity>> GetAnimalsAsync();

    Task<AnimalEntity> GetAnimalAsync(string eartag);

    Task<AnimalEntity> AddAnimalAsync(AnimalEntity animal);

    Task<AnimalEntity> UpdateAnimalAsync(AnimalEntity animal);

    Task<AnimalEntity> DeleteAnimalAsync(string eartag);

}
