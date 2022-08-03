using DemoMyWebAPI.Enums;

namespace DemoMyWebAPI.Data
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? OrderDate { get; set; }
        public StatusOrder Status { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderAddress { get; set; }
        public ICollection<OrderDetail> orderDetails { get; set; }
        public Order()
        {
            orderDetails = new List<OrderDetail>();
        }
    }
}
