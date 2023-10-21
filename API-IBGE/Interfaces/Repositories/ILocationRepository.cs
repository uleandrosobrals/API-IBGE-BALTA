using API_IBGE.Entities;

namespace API_IBGE.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location> GetLocationByIdAsync(string id);
        Task<IEnumerable<Location>> GetLocationsByCityAsync(string city); 
        Task<IEnumerable<Location>> GetLocationsByStateAsync(string state);
        Task<Location> CreateLocationAsync(Location location);
        Task<Location> UpdateLocationAsync(string id, Location location);
        Task<bool> DeleteLocationAsync(string id);
    }
}
