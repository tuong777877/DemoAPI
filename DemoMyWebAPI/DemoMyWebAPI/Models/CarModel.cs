using DemoMyWebAPI.Data;
using DemoMyWebAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMyWebAPI.Model
{
    public class CarModel
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Descirption { get; set; }
        public StatusCar Status { get; set; }
        //public string NameCate { get; set; }
        public int? IdCate { get; set; }
    }
}
