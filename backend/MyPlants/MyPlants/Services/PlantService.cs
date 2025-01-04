using MyPlants.Interfaces;
using MyPlants.Models;
using MyPlants.CustomExceptions;
using AutoMapper;
using MyPlants.Models.DTOs;
using AutoMapper.QueryableExtensions;

namespace MyPlants.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public PlantService(IPlantRepository plantRepository, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _plantRepository = plantRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<PlantDTO> AddAsync(Plant plant)
        {
            if(!await _plantRepository.AddAsync(plant))
            {
                throw new Exception("Failed to add a new plant.");
            }

            return _mapper.Map<PlantDTO>(await _plantRepository.GetByIdAsync(plant.Id));
        }

        public async Task DeleteAsync(int id)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst("sub").ToString();
            var plant = await _plantRepository.GetByIdAsync(id);

            if(plant == null)
            {
                throw new NotFoundException($"Plant with ID={id} was not found.");
            }
            else if(plant.UserId != userId)
            {
                throw new ForbiddenException($"A user can delete only his own plants.");
            }
            else if(!await _plantRepository.DeleteAsync(id))
            {
                throw new Exception($"Failed to delete a plant with ID={id}.");
            }
        }

        public async Task<PlantDTO> GetByIdAsync(int id)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst("sub").ToString();
            var plant = await _plantRepository.GetByIdAsync(id);

            if (plant == null)
            {
                throw new NotFoundException($"Plant with ID={id} was not found.");
            }
            else if (plant.UserId != userId)
            {
                throw new ForbiddenException($"A user can fetch only his own plants.");
            }

            return _mapper.Map<PlantDTO>(plant);
        }

        public async Task<IEnumerable<PlantDTO>> GetByUserAsync()
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst("user_id").Value;
            var plants = await _plantRepository.GetByUserAsync(userId);

            return plants.AsQueryable().ProjectTo<PlantDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<PlantDTO> UpdateAsync(Plant plant)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst("sub").ToString();
            var fetchedPlant = await _plantRepository.GetByIdAsync(plant.Id);

            if (fetchedPlant == null)
            {
                throw new NotFoundException($"Plant with ID={plant.Id} was not found.");
            }
            else if (fetchedPlant.UserId != userId)
            {
                throw new ForbiddenException($"A user can update only his own plants.");
            }
            else if (!await _plantRepository.UpdateAsync(plant))
            {
                throw new Exception($"Failed to update a plant with ID={plant.Id}.");
            }

            return _mapper.Map<PlantDTO>(await _plantRepository.GetByIdAsync(plant.Id));
        }
    }
}
