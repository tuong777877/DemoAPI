namespace DemoMyWebAPI.Models
{
    public class CustomerVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NameCate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}