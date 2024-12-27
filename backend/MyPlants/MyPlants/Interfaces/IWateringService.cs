using MyPlants.Models;

namespace MyPlants.Interfaces
{
    public interface IWateringService
    {
        Task<Watering?> GetByIdAync(int plantId, DateTime date);
        Task<Watering?> AddAsync(Watering watering);
        Task<Watering?> UpdateAsync(Watering watering);
        Task<bool> DeleteAsync(int plantId, DateTime date);
    }
}
