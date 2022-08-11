using System.ComponentModel.DataAnnotations;

namespace DemoMyWebAPI.Models
{
    public class CateCarModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}