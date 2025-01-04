using Microsoft.EntityFrameworkCore;
using MyPlants.Interfaces;
using MyPlants.Models;

namespace MyPlants.Repositories
{
    public class WateringRepository : IWateringRepository
    {
        private readonly AppDbContext _context;

        public WateringRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Watering watering)
        {
            await _context.Waterings.AddAsync(watering);
            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected == 1;
        }

        public async Task<bool> DeleteAsync(int plantId, DateTime date)
        {
            int rowsAffected = await _context.Waterings
                .Where(w => w.PlantId == plantId && w.Date == date)
                .ExecuteDeleteAsync();

            return rowsAffected == 1;
        }

        public Task<Watering?> GetByIdAsync(int plantId, DateTime date)
        {
            return _context.Waterings
                .Include(w => w.Plant)
                .FirstOrDefaultAsync(w => w.PlantId == plantId && w.Date == date);
        }
    }
}
