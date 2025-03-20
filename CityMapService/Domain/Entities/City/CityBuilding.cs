using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.City
{
    public class CityBuilding
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UserCityMap")]
        public int UserCityMapId { get; set; }
        public UserCityMap UserCityMap { get; set; }

        [Required]
        [ForeignKey("Building")]
        public int BuildingId { get; set; }

        public Building.Building Building { get; set; }

        [Required] public int XCoordinate { get; set; }

        [Required] public int YCoordinate { get; set; }

    }
}