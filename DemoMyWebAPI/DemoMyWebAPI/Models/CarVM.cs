using DemoMyWebAPI.Enums;

namespace DemoMyWebAPI.Models
{
    public class CarVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public StatusCar Status { get; set; }
        public string Descirption { get; set; }
        public DateTime? DateRelease { get; set; }
        public string NameCate { get; set; }
    }
}