using API_IBGE.Entities;
using API_IBGE.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_IBGE.Controllers
{
    [Route("api/v1/locations")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationService.GetLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(string id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetLocationsByCity(string city)
        {
            var locations = await _locationService.GetLocationsByCityAsync(city);
            return Ok(locations);
        }

        [HttpGet("state/{state}")]
        public async Task<IActionResult> GetLocationsByState(string state)
        {
            var locations = await _locationService.GetLocationsByStateAsync(state);
            return Ok(locations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] Location location)
        {
            var createdLocation = await _locationService.CreateLocationAsync(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = createdLocation.Id }, createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(string id, [FromBody] Location location)
        {
            var updatedLocation = await _locationService.UpdateLocationAsync(id, location);
            if (updatedLocation == null)
            {
                return NotFound();
            }
            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var result = await _locationService.DeleteLocationAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
