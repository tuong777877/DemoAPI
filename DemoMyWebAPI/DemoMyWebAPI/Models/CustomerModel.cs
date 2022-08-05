using System.ComponentModel.DataAnnotations;

namespace DemoMyWebAPI.Models
{
    public class CustomerModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? IdCate { get; set; }
    }
}
