using System.Security.Claims;
using API.DTO;
using Application.Services;
using Data.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingPlacementController : ControllerBase
    {
        private BuildingPlacementService buildingPlacementService;

        public BuildingPlacementController(BuildingPlacementService buildingPlacementService)
        {
            this.buildingPlacementService = buildingPlacementService;
        }

        [HttpGet("getBuildings")]
        [Authorize]
        public async Task<ActionResult<List<Building>>> GetBuilding()
        {
            var buildings = await buildingPlacementService.GetBuildings();
            return buildings != null ? Ok(buildings) : NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PlaceBuilding([FromBody] PlaceBuildingRequestBody building)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }
            var result = await buildingPlacementService.PlaceBuilding(
                new BuildingToPlace
                {
                    userId = userId,
                    buildingId = building.buildingId,
                    xCoordinate = building.XCoordinate,
                    yCoordinate = building.YCoordinate
                });
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteBuilding(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }
            var result = await buildingPlacementService.DeleteBuilding(userId, id);
            return result ? Ok() : NotFound();
        }
    }
}