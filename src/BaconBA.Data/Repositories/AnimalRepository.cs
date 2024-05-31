using BaconBA.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaconBA.Data;

public class AnimalRepository : IAnimalRepository
{
    private readonly ApplicationDbContext _context;
    public AnimalRepository(ApplicationDbContext context){
        _context = context;
    }
    public async Task<AnimalEntity> AddAnimalAsync(AnimalEntity animal)
    {
        _context.Animals.Add(animal);
        _context.SaveChanges();
        return animal;
    }

    public async Task<AnimalEntity> DeleteAnimalAsync(string eartag)
    {
        var animal = await GetAnimalAsync(eartag);

        if (animal == null){
            return null;
        } else {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return animal;
        }
    }

    public async Task<List<AnimalEntity>> GetAnimalsAsync()
    {
        return await _context.Animals.ToListAsync();
    }

    public async Task<AnimalEntity> GetAnimalAsync(string eartag)
    {
        return await _context.Animals.Where(e => e.Eartag == eartag).FirstOrDefaultAsync();
    }

    public async Task<AnimalEntity> UpdateAnimalAsync(AnimalEntity animal)
    {
        var animalEntity = await GetAnimalAsync(animal.Eartag);

        if (animal == null){
            return null!;
    } else {
            _context.Animals.Update(animal);
            _context.SaveChanges();
            return animal;
        }
    }

}
