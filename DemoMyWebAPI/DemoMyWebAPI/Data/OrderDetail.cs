namespace DemoMyWebAPI.Data
{
    public class OrderDetail
    {
        public Guid IdOrder { get; set; }
        public Guid IdCar { get; set; }
        public int Quantity { get; set; }
        public float UntilPrice { get; set; }
        public int Discount { get; set; }
        public Car Car { get; set; }
        public Order Order { get; set; }
    }
}