using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMyWebAPI.Data
{
    [Table ("Car")]
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        public StatusCar Status { get; set; }
        public string Descirption { get; set; }
        public DateTime DateRelease { get; set; }
        public enum StatusCar
        {
            New,
            Payment,
            Sold,
            Cancel
        }
        public int? IdCate { get; set; }
        [ForeignKey("IdCate")]
        public CateCar catecar { get; set; }
    }
}
