using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMyWebAPI.Data
{
    [Table("CategoryCar")]
    public class CateCar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}