using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.User;

namespace Data.Entities.City
{
    public class UserCityMap
    {
        [Key]
        [ForeignKey("UserGameData")]

        public int Id { get; set; }

        [Required]
        public UserGameData UserGameData { get; set; }

        [Required]
        public ICollection<UserCityExtension> Extensions { get; set; } = new HashSet<UserCityExtension>();

        public ICollection<CityBuilding> Buildings { get; set; } = new HashSet<CityBuilding>();
    }
}