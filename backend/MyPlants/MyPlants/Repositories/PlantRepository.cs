using Microsoft.EntityFrameworkCore;
using MyPlants.Interfaces;
using MyPlants.Models;

namespace MyPlants.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly AppDbContext _context;

        public PlantRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> AddAsync(Plant plant)
        {
            await _context.Plants.AddAsync(plant);
            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int rowsAffected = await _context.Plants
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            return rowsAffected == 1;
        }

        public async Task<Plant?> GetByIdAsync(int id)
        {
            return await _context.Plants
                .Include(p => p.Waterings)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Plant>> GetByUserAsync(string userId)
        {
            return await _context.Plants
                .Include(p => p.Waterings)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Plant plant)
        {
            _context.Entry(plant).State = EntityState.Modified;
            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected == 1;
        }
    }
}
