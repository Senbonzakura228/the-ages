using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.City
{
    public class UserCityMap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ICollection<UserCityExtension> Extensions { get; set; } = new HashSet<UserCityExtension>();

        public ICollection<CityBuilding> Buildings { get; set; } = new HashSet<CityBuilding>();
    }
}