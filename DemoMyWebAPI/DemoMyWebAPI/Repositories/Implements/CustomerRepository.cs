using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repositories.Constracts;

namespace DemoMyWebAPI.Repositories.Implements
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarStoreContext _context;

        public CustomerRepository(CarStoreContext context)
        {
            _context = context;
        }

        public List<CustomerVM> GetAll()
        {
            var cus = _context.Customers.Select(c => new CustomerVM
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Username = c.Username,
                Password = c.Password,
                NameCate = c.catecus.Name,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
            });
            return cus.ToList();
        }

        public CustomerVM GetById(string id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if (cus != null)
            {
                return new CustomerVM
                {
                    Id = cus.Id,
                    Name = cus.Name,
                    Email = cus.Email,
                    Username = cus.Username,
                    Password = cus.Password,
                    NameCate = cus.catecus.Name,
                    Address = cus.Address,
                    PhoneNumber = cus.PhoneNumber,
                };
            }
            return null;
        }

        public CustomerVM Create(CustomerModel model)
        {
            var cus = new Customer
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                IdCate = model.IdCate,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
            };
            _context.Add(cus);
            _context.SaveChanges();
            return new CustomerVM
            {
                Id = cus.Id,
                Name = cus.Name,
                Email = cus.Email,
                Username = cus.Username,
                Password = cus.Password,
                NameCate = cus.catecus.Name,
                Address = cus.Address,
                PhoneNumber = cus.PhoneNumber,
            };
        }

        public void Update(CustomerVM cusVM)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == cusVM.Id);
            if (cus != null)
            {
                cusVM.Name = cusVM.Name;
                cusVM.Email = cusVM.Email;
                cusVM.Username = cusVM.Username;
                cusVM.Password = cusVM.Password;
                cusVM.NameCate = cusVM.NameCate;
                cusVM.Address = cusVM.Address;
                cusVM.PhoneNumber = cusVM.PhoneNumber;
                _context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if (cus != null)
            {
                _context.Remove(cus);
                _context.SaveChanges();
            }
        }
    }
}