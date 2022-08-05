using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMyWebAPI.Data
{
    [Table("CategoryCustomer")]
    public class CateCustomer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
