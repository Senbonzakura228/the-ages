using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.City;

namespace Data.Entities.User
{
    public class UserGameData
    {
        [Key]
        [ForeignKey("UserAccount")]
        public int Id { get; set; }

        [Required]
        public UserAccount UserAccount { get; set; }

        [Required]
        public UserCityMap UserCityMap { get; set; }
    }
}