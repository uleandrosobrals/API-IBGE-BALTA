using API_IBGE.Entities;
using API_IBGE.Interfaces.Repositories;
using API_IBGE.Interfaces.Services;

namespace API_IBGE.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _locationRepository.GetLocationsAsync();
        }

        public async Task<Location> GetLocationByIdAsync(string id)
        {
            return await _locationRepository.GetLocationByIdAsync(id);
        }

        public async Task<IEnumerable<Location>> GetLocationsByCityAsync(string city)
        {
            return await _locationRepository.GetLocationsByCityAsync(city);
        }

        public async Task<IEnumerable<Location>> GetLocationsByStateAsync(string state)
        {
            return await _locationRepository.GetLocationsByStateAsync(state);
        }

        public async Task<Location> CreateLocationAsync(Location location)
        {
            return await _locationRepository.CreateLocationAsync(location);
        }

        public async Task<Location> UpdateLocationAsync(string id, Location location)
        {
            return await _locationRepository.UpdateLocationAsync(id, location);
        }

        public async Task<bool> DeleteLocationAsync(string id)
        {
            return await _locationRepository.DeleteLocationAsync(id);
        }
    }
}
