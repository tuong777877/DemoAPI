using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMyWebAPI.Data
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public int? IdCate { get; set; }
        [ForeignKey("IdCate")]
        public CateCustomer catecus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
