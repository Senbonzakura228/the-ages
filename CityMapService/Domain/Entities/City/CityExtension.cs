using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.City
{
    public class CityExtension
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public int XCoordinate { get; set; }

        [Required] public int YCoordinate { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }
    }
}