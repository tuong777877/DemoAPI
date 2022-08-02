using DemoMyWebAPI.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DemoMyWebAPI.Data.Car;

namespace DemoMyWebAPI.Model
{
    public class CarModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public float Price { get; set; }
        public string Descirption { get; set; }
        [Required]
        [MaxLength(50)]
        public StatusCar Status { get; set; }
        public int IdCate { get; set; }
        [ForeignKey("IdCate")]
        public CateCar catecar { get; set; }
    }
}
