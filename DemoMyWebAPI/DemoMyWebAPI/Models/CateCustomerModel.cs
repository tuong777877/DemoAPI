using System.ComponentModel.DataAnnotations;

namespace DemoMyWebAPI.Models
{
    public class CateCustomerModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
