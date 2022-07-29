namespace DemoMyWebAPI.Model
{
    public class Car
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
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
    }
}
