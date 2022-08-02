using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMyWebAPI.Data
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public float Price { get; set; }
        [Required]
        [MaxLength(50)]
        public StatusCar Status { get; set; }
        public string Descirption { get; set; }
        public DateTime? DateRelease { get; set; }
        public enum StatusCar
        {
            New = 0,
            Payment = 1,
            Sold = 2,
            Cancel = 3,
        }
        public int? IdCate { get; set; }
        [ForeignKey("IdCate")]
        public CateCar catecar { get; set; }
        public ICollection<OrderDetail> orderDetails { get; set; }
        public Car()
        {
            orderDetails = new List<OrderDetail>();
        }
    }
}
