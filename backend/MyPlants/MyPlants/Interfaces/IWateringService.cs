using MyPlants.Models;

namespace MyPlants.Interfaces
{
    public interface IWateringService
    {
        Task<Watering> AddAsync(Watering watering);
        Task DeleteAsync(int plantId, DateTime date);
    }
}
