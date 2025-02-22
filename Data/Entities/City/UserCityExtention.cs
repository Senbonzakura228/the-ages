using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.User;

namespace Data.Entities.City
{
    public class UserCityExtension
    {
        public int CityMapId { get; set; }
        public int CityExtensionId { get; set; }

        [Required]
        [ForeignKey(nameof(CityMapId))]
        public UserCityMap UserCityMap { get; set; }

        [Required]
        [ForeignKey(nameof(CityExtensionId))]
        public CityExtension CityExtension { get; set; }
    }
}