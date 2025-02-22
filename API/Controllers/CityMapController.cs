using System.Security.Claims;
using Application.Services;
using Data.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityMapController : ControllerBase
    {
        private CityMapService cityMapService;

        public CityMapController(CityMapService cityMapService)
        {
            this.cityMapService = cityMapService;
        }

        [HttpGet("getCityMap")]
        [Authorize]
        public async Task<ActionResult<CityMap>> GetCityMap()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }
            var cityMap = await cityMapService.GetCityMap(userId);
            return cityMap != null ? Ok(cityMap) : NoContent();
        }
    }
}