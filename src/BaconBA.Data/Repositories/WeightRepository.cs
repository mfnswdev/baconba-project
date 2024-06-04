using BaconBA.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaconBA.Data;

public class WeightRepository : IWeightRepository
{
    public readonly ApplicationDbContext _context;
    public WeightRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Weight> AddWeightAsync(Weight weight)
    {
        _context.Weights.Add(weight);
        await _context.SaveChangesAsync();
        return weight;
    }

    public async Task<Weight> DeleteWeightAsync(int id)
    {
        var weight = await GetWeightAsync(id);

        if (weight == null)
        {
            return null!;
        }
        else
            _context.Weights.Remove(weight);
        await _context.SaveChangesAsync();
        return weight;
    }

    public async Task<Weight> GetWeightAsync(int id)
    {
        var response = await _context.Weights.Where(w => w.Id == id).FirstOrDefaultAsync();
        if (response == null)
        {
            return null!;
        }
        else
        {
            return response;
        }
    }

    public async Task<List<Weight>> GetWeightsAsync(string eartag)
    {
        var response = await _context.Weights.Where(w => w.Animal.Eartag == eartag).ToListAsync();
        if (response == null)
        {
            return null!;
        }
        else
        {
            return response;
        }
    }

    public async Task<Weight> UpdateWeightAsync(Weight weight)
    {
        var response = await GetWeightAsync(weight.Id);
        if (response == null)
        {
            return null!;
        }
        else
        {
            _context.Weights.Update(weight);
            _context.SaveChanges();
            return response;
        }
    }
}
