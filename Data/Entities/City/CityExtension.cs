using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.City
{
    public class CityExtension
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public int XCoordinate { get; set; }

        [Required] public int YCoordinate { get; set; }

        [Required]
        public int width { get; set; }

        [Required]
        public int height { get; set; }
    }
}